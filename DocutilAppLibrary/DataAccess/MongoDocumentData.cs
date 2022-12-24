using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocutilAppLibrary.DataAccess
{
    public class MongoDocumentData : IDocumentData
    {
        private readonly IMongoCollection<DocumentModel> _documents;
        private readonly IDbConnection _db;


        public MongoDocumentData(Interfaces.IDbConnection db) {
            _documents = db.DocumentCollection;
        }

        //Load All Documents by Project
        public async Task<List<DocumentModel>> GetAllDocumentsByProject(string projectId)
        {
            var result = await _documents.FindAsync(d => d.ProjectId == projectId);
            return result.ToList();

        }

        //load All Documents by User
        public async Task<List<DocumentModel>> GetAllDocumentsByUser(BasicUserModel user)
        {
            var result = await _documents.FindAsync(d => d.UsersReadClaim.Contains(user));
            return result.ToList();
        }


        //load All Documents by Parent Directory
        public async Task<List<DocumentModel>> GetAllDocumentsByDirectory(string parentId)
        {
            var result = await _documents.FindAsync(d => d.ParentDirectoryId == parentId);
            return result.ToList();
        }


        //Get Document By ID
        public async Task<DocumentModel> GetDocumentById(string documentId)
        {
            var result = await _documents.FindAsync(d => d.Id == documentId);
            return result.FirstOrDefault();
        }

        //CreateDocument
        public async Task CreateDocument(DocumentModel document)
        {
            var client = _db.Client;
            using var session = await client.StartSessionAsync();
            session.StartTransaction();
            try
            {
                //Add Document to DocumentCollection
                var db = client.GetDatabase(_db.DbName);
                var documentsInTransaction = db.GetCollection<DocumentModel>(_db.DocumentCollectionName);
                await documentsInTransaction.InsertOneAsync(document);

            }
            catch (Exception)
            {

                throw;
            }

        }

        //CreateRevision
        public async Task CreateRevision(DocumentModel document, RevisionModel revision)
        {
            var client = _db.Client;
            using var session = await client.StartSessionAsync();
            session.StartTransaction();
            try
            {
                //Get Document from Database in order to get current Transactions
                var db = client.GetDatabase(_db.DbName);
                var documentsInTransaction = db.GetCollection<DocumentModel>(_db.DocumentCollectionName);
                var doc = await this.GetDocumentById(document.Id);
                //Edit Doc
                doc.Revisions.Add(revision);
                //Replace Doc
                await documentsInTransaction.ReplaceOneAsync(d => d.Id == doc.Id, doc);
                //Commit
                await session.CommitTransactionAsync();

            }
            catch (Exception)
            {
                await session.AbortTransactionAsync();
                throw;
            }

        }

        //DeleteRevision
        public async Task DeleteRevision(DocumentModel document, RevisionModel revision)
        {
            var client = _db.Client;
            using var session = await client.StartSessionAsync();
            session.StartTransaction();
            try
            {
                //Get Document from Database in order to get current Transactions
                var db = client.GetDatabase(_db.DbName);
                var documentsInTransaction = db.GetCollection<DocumentModel>(_db.DocumentCollectionName);
                var doc = await this.GetDocumentById(document.Id);
                //Edit Doc
                doc.Revisions.Remove(revision);

                //Replace Doc
                await documentsInTransaction.ReplaceOneAsync(d => d.Id == doc.Id, doc);
                //Commit
                await session.CommitTransactionAsync();

            }
            catch (Exception)
            {
                await session.AbortTransactionAsync();
                throw;
            }

        }

        //Update Revision

        //Update Document

        //Delete Document
        public Task DeleteDocument(DocumentModel document)
        {
            var filter = Builders<DocumentModel>.Filter.Eq("Id", document.Id);
            return _documents.DeleteOneAsync(filter);
        }
    }
}
