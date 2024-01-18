﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DQFunnel.BusinessLogic.Interfaces;
using DQFunnel.BusinessLogic.Services;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.ViewModel;
using DQFunnel.DataAccess;
using DQFunnel.DataAccess.Interfaces;

namespace DQFunnel.BusinessLogic
{
    public class RelatedFileLogic : IRelatedFileLogic
    {
        private DapperContext _context;
        private IGenericAPI genericAPI;
        public RelatedFileLogic(string connectionstring, string apiGateway)
        {
            this._context = new DapperContext(connectionstring);
            genericAPI = new GenericAPI(apiGateway);
        }
        private ResultAction MessageResult(bool bSuccess, string message)
        {
            return MessageResult(bSuccess, message, null);
        }

        private ResultAction MessageResult(bool bSuccess, string message, object objResult)
        {
            ResultAction result = new ResultAction()
            {
                bSuccess = bSuccess,
                ErrorNumber = (bSuccess ? "0" : "666"),
                Message = message,
                ResultObj = objResult
            };

            return result;

        }
        public ResultAction DeleteRelatedFile(long Id)
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    var existing = uow.RelatedFileRepository.GetRelatedFileById(Id);
                    if (existing == null)
                    {
                        return result = MessageResult(false, "Data not found");
                    }
                    uow.RelatedFileRepository.Delete(existing);
                    result = MessageResult(true, "Delete Success");
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }

        public ResultAction GetRelatedFile()
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    var existing = uow.RelatedFileRepository.GetAll();
                    result = MessageResult(true, "Success", existing);
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }

        public ResultAction InsertRelatedFile(Req_CustomerSettingInsertRelatedFile_ViewModel objEntity)
        {
            ResultAction result = new ResultAction();

            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);

                    var pathFolder = Environment.CurrentDirectory.Replace("DQFunnel.WebApi", "Uploads\\RelatedFile");

                    var setName = objEntity.DocumentName;
                    var fileName = objEntity.File.FileName;
                    int periodIndex = fileName.IndexOf('.');
                    var documentType = fileName.Substring(fileName.Length - periodIndex);

                    var filePath = Path.Combine(pathFolder, setName);

                    var existing = uow.RelatedFileRepository.GetRelatedFileByDocumentPath(filePath);
                    string newFilePath = null;
                    if (existing != null)
                    {
                        int number = 1;

                        while (true)
                        {
                            var newFileName = $"{setName} ({number})";
                            newFilePath = Path.Combine(pathFolder, newFileName);

                            var newExisting = uow.RelatedFileRepository.GetRelatedFileByDocumentPath(newFilePath);

                            if (newExisting == null)
                            {
                                fileName = newFileName;
                                break;
                            }
                            number++;
                        }
                    }

                    filePath = Path.Combine(pathFolder, setName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        objEntity.File.CopyTo(fileStream);
                    }

                    var insertModel = new CpRelatedFile();
                    insertModel.RFileID = 0;
                    insertModel.CustomerID = objEntity.CustomerID;
                    insertModel.DocumentName = setName + "." + documentType;
                    insertModel.DocumentType = objEntity.DocumentType;
                    insertModel.DocumentPath = filePath + "." + documentType;
                    insertModel.CreateDate = DateTime.Now;
                    insertModel.CreateUserID = (string.IsNullOrEmpty(objEntity.CreateUserID)) ? 0 : int.Parse(objEntity.CreateUserID);
                    insertModel.ModifyDate = DateTime.Now;
                    insertModel.ModifyUserID = objEntity.ModifyUserID;

                    uow.RelatedFileRepository.Add(insertModel);

                    result = MessageResult(true, "Insert Data Success!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result = MessageResult(false, ex.Message);
            }
            return result;
        }

        public ResultAction UpdateRelatedFile(long Id, CpRelatedFile objEntity)
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    var existing = uow.RelatedFileRepository.GetRelatedFileById(Id);
                    if (existing == null)
                    {
                        return result = MessageResult(false, "Data not found");
                    }
                    existing = objEntity;
                    existing.RFileID = Id;
                    existing.ModifyDate = DateTime.Now;
                    uow.RelatedFileRepository.Update(existing);
                    result = MessageResult(true, "Update Success");
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }
        public ResultAction GetRelatedFileByCustomerID(long customerID)
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    var existing = uow.RelatedFileRepository.GetRelatedFileByCustomerID(customerID);
                    result = MessageResult(true, "Success", existing);
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }
    }
}
