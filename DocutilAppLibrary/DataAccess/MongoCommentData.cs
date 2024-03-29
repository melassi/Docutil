﻿namespace DocutilAppLibrary.DataAccess
{
    public class MongoCommentData : ICommentData
    {
        private readonly IMongoCollection<CommentModel> _comments;
        private readonly IDbConnection _db;
        private readonly IDocumentData _documentdata;

        public MongoCommentData(Interfaces.IDbConnection db, IDocumentData documentData)
        {
            _db = db;
            _comments = db.CommentCollection;
            _documentdata = documentData;
        }

        //GetCommentByBasicUser
        public async Task<List<CommentModel>> GetCommentByUser(BasicUserModel user)
        {
            var output = await _comments.FindAsync(c => c.Author == user);
            return output.ToList();

        }

        //UpdateComment
        public Task UpdateComment(CommentModel comment)
        {
            var filter = Builders<CommentModel>.Filter.Eq("Id", comment.Id);
            return _comments.ReplaceOneAsync(filter, comment, new ReplaceOptions { IsUpsert = true });
        }

        //CreateComment
        public async Task CreateComment(CommentModel comment)
        {
            var client = _db.Client;
            using var session = await client.StartSessionAsync();
            session.StartTransaction();
            try
            {
                var db = client.GetDatabase(_db.DbName);
                var commentsInTransaction = db.GetCollection<CommentModel>(_db.CommentCollectionName);
                await commentsInTransaction.InsertOneAsync(comment);

                var documentsInTransaction = db.GetCollection<DocumentModel>(_db.DocumentCollectionName);
                var document = await _documentdata.GetDocumentById(comment.DocumentId);
                document.Comments.Add(new BasicCommentModel(comment));
                await documentsInTransaction.ReplaceOneAsync(d => d.Id == document.Id, document);

                await session.CommitTransactionAsync();

            }
            catch (Exception)
            {
                await session.AbortTransactionAsync();
                throw;
            }



        }

        //DeleteComment
        public Task DeleteComment(CommentModel comment)
        {
            var filter = Builders<CommentModel>.Filter.Eq("Id", comment.Id);
            return _comments.DeleteOneAsync(filter);
        }


    }
}
