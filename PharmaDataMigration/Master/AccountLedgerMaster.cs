using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PharmaDAL.Entity;

namespace PharmaDataMigration.Master
{
    public class AccountLedgerMaster
    {
        private DBFConnectionManager dbConnection;

        public AccountLedgerMaster()
        {
            dbConnection = new DBFConnectionManager(Common.DataDirectory);
        }

        public int InsertControlCodesData()
        {
            try
            {
                string query = "select * from ACM where slcd = 'CC'";

                DataTable dtControlCodesMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.AccountLedgerMaster> listControlCodesMaster = new List<PharmaDAL.Entity.AccountLedgerMaster>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var maxAccountLedgerID = context.AccountLedgerMaster.Count();
                    int accountLedgerTypeID = context.AccountLedgerType.Where(p => p.SystemName == PharmaBusinessObjects.Common.Constants.AccountLedgerType.ControlCodes).FirstOrDefault().AccountLedgerTypeID;
                    
                    if (dtControlCodesMaster != null && dtControlCodesMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtControlCodesMaster.Rows)
                        {
                            maxAccountLedgerID++;
                            string accountTypeShortName = Convert.ToString(dr["Actyp"]).TrimEnd();
                            int accountTypeID = context.AccountType.Where(p => p.AccountTypeShortName == accountTypeShortName).FirstOrDefault().AccountTypeID;
                            string accountLedgerCode = "L" + maxAccountLedgerID.ToString().PadLeft(6, '0');
                            string originalAccountLedgerCode = Convert.ToString(dr["ACNO"]).TrimEnd();
                            Common.controlCodeMap.Add(new ControlCodeMap() { OriginalControlCode = originalAccountLedgerCode, MappedControlCode = accountLedgerCode });

                            PharmaDAL.Entity.AccountLedgerMaster newControlCodeMaster = new PharmaDAL.Entity.AccountLedgerMaster()
                            {
                                AccountLedgerName = Convert.ToString(dr["ACName"]).TrimEnd(),
                                AccountLedgerCode = accountLedgerCode,
                                AccountLedgerTypeId = accountLedgerTypeID,
                                AccountTypeId = accountTypeID,
                                OpeningBalance = Convert.ToDouble(dr["Abop"]),
                                CreditDebit = Convert.ToDouble(dr["Abop"]) > 0 ? Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.D) : Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.C),
                                Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true,
                                CreditControlCodeID = null,
                                DebitControlCodeID = null,
                                CreatedBy = "admin",
                                CreatedOn = DateTime.Now,
                                SalePurchaseTaxType = null
                            };

                            listControlCodesMaster.Add(newControlCodeMaster);
                        }
                    }

                    context.AccountLedgerMaster.AddRange(listControlCodesMaster);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertIncomeLedgerData()
        {
            try
            {
                string query = "select * from ACM where slcd = '01'";

                DataTable dtIncomeLedgerMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.AccountLedgerMaster> listIncomeLedgerMaster = new List<PharmaDAL.Entity.AccountLedgerMaster>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var maxAccountLedgerID = context.AccountLedgerMaster.Count();
                    int accountLedgerTypeID = context.AccountLedgerType.Where(p => p.SystemName == PharmaBusinessObjects.Common.Constants.AccountLedgerType.IncomeLedger).FirstOrDefault().AccountLedgerTypeID;
                    
                    if (dtIncomeLedgerMaster != null && dtIncomeLedgerMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtIncomeLedgerMaster.Rows)
                        {
                            maxAccountLedgerID++;
                            string accountTypeShortName = Convert.ToString(dr["Actyp"]).TrimEnd();
                            int accountTypeID = context.AccountType.Where(p => p.AccountTypeShortName == accountTypeShortName).FirstOrDefault().AccountTypeID;
                            string accountLedgerCode = "L" + maxAccountLedgerID.ToString().PadLeft(6, '0');
                            string originalAccountLedgerCode = Convert.ToString(dr["ACNO"]).TrimEnd();
                            string originalCreditControlCode = Convert.ToString(dr["Cac"]).TrimEnd();
                            string mappedCreditControlCode = Common.controlCodeMap.Where(q => q.OriginalControlCode == originalCreditControlCode).FirstOrDefault().MappedControlCode;
                            int creditControlCodeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == mappedCreditControlCode).FirstOrDefault().AccountLedgerID;
                            string originalDebitControlCode = Convert.ToString(dr["Cad"]).TrimEnd();
                            string mappedDebitControlCode = Common.controlCodeMap.Where(q => q.OriginalControlCode == originalDebitControlCode).FirstOrDefault().MappedControlCode;
                            int debitControlCodeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == mappedDebitControlCode).FirstOrDefault().AccountLedgerID;
                            Common.accountLedgerCodeMap.Add(new AccountLedgerCodeMap() { OriginalAccountLedgerCode = originalAccountLedgerCode, MappedAccountLedgerCode = accountLedgerCode, AccountLedgerTypeID = accountLedgerTypeID });

                            PharmaDAL.Entity.AccountLedgerMaster newIncomeLedgerMaster = new PharmaDAL.Entity.AccountLedgerMaster()
                            {
                                AccountLedgerName = Convert.ToString(dr["ACName"]).TrimEnd(),
                                AccountLedgerCode = accountLedgerCode,
                                AccountLedgerTypeId = accountLedgerTypeID,
                                AccountTypeId = accountTypeID,
                                OpeningBalance = Convert.ToDouble(dr["Abop"]),
                                CreditDebit = Convert.ToDouble(dr["Abop"]) > 0 ? Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.D) : Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.C),
                                Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true,
                                CreditControlCodeID = creditControlCodeID,
                                DebitControlCodeID = debitControlCodeID,
                                CreatedBy = "admin",
                                CreatedOn = DateTime.Now,
                                SalePurchaseTaxType = null
                            };

                            listIncomeLedgerMaster.Add(newIncomeLedgerMaster);
                        }
                    }

                    context.AccountLedgerMaster.AddRange(listIncomeLedgerMaster);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertExpenditureLedgerData()
        {
            try
            {
                string query = "select * from ACM where slcd = '02'";

                DataTable dtExpenditureLedgerMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.AccountLedgerMaster> listExpenditureLedgerMaster = new List<PharmaDAL.Entity.AccountLedgerMaster>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var maxAccountLedgerID = context.AccountLedgerMaster.Count();
                    int accountLedgerTypeID = context.AccountLedgerType.Where(p => p.SystemName == PharmaBusinessObjects.Common.Constants.AccountLedgerType.ExpenditureLedger).FirstOrDefault().AccountLedgerTypeID;

                    if (dtExpenditureLedgerMaster != null && dtExpenditureLedgerMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtExpenditureLedgerMaster.Rows)
                        {
                            maxAccountLedgerID++;
                            string accountTypeShortName = Convert.ToString(dr["Actyp"]).TrimEnd();
                            int accountTypeID = context.AccountType.Where(p => p.AccountTypeShortName == accountTypeShortName).FirstOrDefault().AccountTypeID;
                            string accountLedgerCode = "L" + maxAccountLedgerID.ToString().PadLeft(6, '0');
                            string originalAccountLedgerCode = Convert.ToString(dr["ACNO"]).TrimEnd();
                            string originalCreditControlCode = Convert.ToString(dr["Cac"]).TrimEnd();
                            string mappedCreditControlCode = Common.controlCodeMap.Where(q => q.OriginalControlCode == originalCreditControlCode).FirstOrDefault().MappedControlCode;
                            int creditControlCodeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == mappedCreditControlCode).FirstOrDefault().AccountLedgerID;
                            string originalDebitControlCode = Convert.ToString(dr["Cad"]).TrimEnd();
                            string mappedDebitControlCode = Common.controlCodeMap.Where(q => q.OriginalControlCode == originalDebitControlCode).FirstOrDefault().MappedControlCode;
                            int debitControlCodeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == mappedDebitControlCode).FirstOrDefault().AccountLedgerID;
                            Common.accountLedgerCodeMap.Add(new AccountLedgerCodeMap() { OriginalAccountLedgerCode = originalAccountLedgerCode, MappedAccountLedgerCode = accountLedgerCode, AccountLedgerTypeID = accountLedgerTypeID });

                            PharmaDAL.Entity.AccountLedgerMaster newExpenditureLedgerMaster = new PharmaDAL.Entity.AccountLedgerMaster()
                            {
                                AccountLedgerName = Convert.ToString(dr["ACName"]).TrimEnd(),
                                AccountLedgerCode = accountLedgerCode,
                                AccountLedgerTypeId = accountLedgerTypeID,
                                AccountTypeId = accountTypeID,
                                OpeningBalance = Convert.ToDouble(dr["Abop"]),
                                CreditDebit = Convert.ToDouble(dr["Abop"]) > 0 ? Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.D) : Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.C),
                                Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true,
                                CreditControlCodeID = creditControlCodeID,
                                DebitControlCodeID = debitControlCodeID,
                                CreatedBy = "admin",
                                CreatedOn = DateTime.Now,
                                SalePurchaseTaxType = null
                            };

                            listExpenditureLedgerMaster.Add(newExpenditureLedgerMaster);
                        }
                    }

                    context.AccountLedgerMaster.AddRange(listExpenditureLedgerMaster);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertTransactionLedgerData()
        {
            try
            {
                string query = "select * from ACM where slcd = '03'";

                DataTable dtTransactionLedgerMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.AccountLedgerMaster> listTransactionLedgerMaster = new List<PharmaDAL.Entity.AccountLedgerMaster>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var maxAccountLedgerID = context.AccountLedgerMaster.Count();
                    int accountLedgerTypeID = context.AccountLedgerType.Where(p => p.SystemName == PharmaBusinessObjects.Common.Constants.AccountLedgerType.TransactionBooks).FirstOrDefault().AccountLedgerTypeID;

                    if (dtTransactionLedgerMaster != null && dtTransactionLedgerMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtTransactionLedgerMaster.Rows)
                        {
                            maxAccountLedgerID++;
                            string accountTypeShortName = Convert.ToString(dr["Actyp"]).TrimEnd();
                            int accountTypeID = context.AccountType.Where(p => p.AccountTypeShortName == accountTypeShortName).FirstOrDefault().AccountTypeID;
                            string accountLedgerCode = "L" + maxAccountLedgerID.ToString().PadLeft(6, '0');
                            string originalAccountLedgerCode = Convert.ToString(dr["ACNO"]).TrimEnd();
                            string originalCreditControlCode = Convert.ToString(dr["Cac"]).TrimEnd();
                            string mappedCreditControlCode = Common.controlCodeMap.Where(q => q.OriginalControlCode == originalCreditControlCode).FirstOrDefault().MappedControlCode;
                            int creditControlCodeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == mappedCreditControlCode).FirstOrDefault().AccountLedgerID;
                            string originalDebitControlCode = Convert.ToString(dr["Cad"]).TrimEnd();
                            string mappedDebitControlCode = Common.controlCodeMap.Where(q => q.OriginalControlCode == originalDebitControlCode).FirstOrDefault().MappedControlCode;
                            int debitControlCodeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == mappedDebitControlCode).FirstOrDefault().AccountLedgerID;
                            Common.accountLedgerCodeMap.Add(new AccountLedgerCodeMap() { OriginalAccountLedgerCode = originalAccountLedgerCode, MappedAccountLedgerCode = accountLedgerCode, AccountLedgerTypeID = accountLedgerTypeID });

                            PharmaDAL.Entity.AccountLedgerMaster newTransactionLedgerMaster = new PharmaDAL.Entity.AccountLedgerMaster()
                            {
                                AccountLedgerName = Convert.ToString(dr["ACName"]).TrimEnd(),
                                AccountLedgerCode = accountLedgerCode,
                                AccountLedgerTypeId = accountLedgerTypeID,
                                AccountTypeId = accountTypeID,
                                OpeningBalance = Convert.ToDouble(dr["Abop"]),
                                CreditDebit = Convert.ToDouble(dr["Abop"]) > 0 ? Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.D) : Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.C),
                                Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true,
                                CreditControlCodeID = creditControlCodeID,
                                DebitControlCodeID = debitControlCodeID,
                                CreatedBy = "admin",
                                CreatedOn = DateTime.Now,
                                SalePurchaseTaxType = null
                            };

                            listTransactionLedgerMaster.Add(newTransactionLedgerMaster);
                        }
                    }

                    context.AccountLedgerMaster.AddRange(listTransactionLedgerMaster);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertGeneralLedgerData()
        {
            try
            {
                string query = "select * from ACM where slcd = '04'";

                DataTable dtGeneralLedgerMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.AccountLedgerMaster> listGeneralLedgerMaster = new List<PharmaDAL.Entity.AccountLedgerMaster>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var maxAccountLedgerID = context.AccountLedgerMaster.Count();
                    int accountLedgerTypeID = context.AccountLedgerType.Where(p => p.SystemName == PharmaBusinessObjects.Common.Constants.AccountLedgerType.GeneralLedger).FirstOrDefault().AccountLedgerTypeID;

                    if (dtGeneralLedgerMaster != null && dtGeneralLedgerMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtGeneralLedgerMaster.Rows)
                        {
                            maxAccountLedgerID++;
                            string accountTypeShortName = Convert.ToString(dr["Actyp"]).TrimEnd();
                            int accountTypeID = context.AccountType.Where(p => p.AccountTypeShortName == accountTypeShortName).FirstOrDefault().AccountTypeID;
                            string accountLedgerCode = "L" + maxAccountLedgerID.ToString().PadLeft(6, '0');
                            string originalAccountLedgerCode = Convert.ToString(dr["ACNO"]).TrimEnd();
                            string originalCreditControlCode = Convert.ToString(dr["Cac"]).TrimEnd();
                            string mappedCreditControlCode = Common.controlCodeMap.Where(q => q.OriginalControlCode == originalCreditControlCode).FirstOrDefault().MappedControlCode;
                            int creditControlCodeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == mappedCreditControlCode).FirstOrDefault().AccountLedgerID;
                            string originalDebitControlCode = Convert.ToString(dr["Cad"]).TrimEnd();
                            string mappedDebitControlCode = Common.controlCodeMap.Where(q => q.OriginalControlCode == originalDebitControlCode).FirstOrDefault().MappedControlCode;
                            int debitControlCodeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == mappedDebitControlCode).FirstOrDefault().AccountLedgerID;
                            Common.accountLedgerCodeMap.Add(new AccountLedgerCodeMap() { OriginalAccountLedgerCode = originalAccountLedgerCode, MappedAccountLedgerCode = accountLedgerCode, AccountLedgerTypeID = accountLedgerTypeID });

                            PharmaDAL.Entity.AccountLedgerMaster newGeneralLedgerMaster = new PharmaDAL.Entity.AccountLedgerMaster()
                            {
                                AccountLedgerName = Convert.ToString(dr["ACName"]).TrimEnd(),
                                AccountLedgerCode = accountLedgerCode,
                                AccountLedgerTypeId = accountLedgerTypeID,
                                AccountTypeId = accountTypeID,
                                OpeningBalance = Convert.ToDouble(dr["Abop"]),
                                CreditDebit = Convert.ToDouble(dr["Abop"]) > 0 ? Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.D) : Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.C),
                                Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true,
                                CreditControlCodeID = creditControlCodeID,
                                DebitControlCodeID = debitControlCodeID,
                                CreatedBy = "admin",
                                CreatedOn = DateTime.Now,
                                SalePurchaseTaxType = null
                            };

                            listGeneralLedgerMaster.Add(newGeneralLedgerMaster);
                        }
                    }

                    context.AccountLedgerMaster.AddRange(listGeneralLedgerMaster);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertPurchaseLedgerData()
        {
            try
            {
                string query = "select * from ACM where slcd = '05'";

                DataTable dtPurchaseLedgerMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.AccountLedgerMaster> listPurchaseLedgerMaster = new List<PharmaDAL.Entity.AccountLedgerMaster>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var maxAccountLedgerID = context.AccountLedgerMaster.Count();
                    int accountLedgerTypeID = context.AccountLedgerType.Where(p => p.SystemName == PharmaBusinessObjects.Common.Constants.AccountLedgerType.PurchaseLedger).FirstOrDefault().AccountLedgerTypeID;

                    if (dtPurchaseLedgerMaster != null && dtPurchaseLedgerMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtPurchaseLedgerMaster.Rows)
                        {
                            decimal? salePurchaseTaxType = null;

                            if(string.Compare(Convert.ToString(dr["ACNAME"]).TrimEnd(),"PURCHASE - TAXABLE 5%") == 0)
                            {
                                salePurchaseTaxType = 5;
                            }
                            else if(string.Compare(Convert.ToString(dr["ACNAME"]).TrimEnd(), "PURCHASE - TAXABLE 12.5%") == 0)
                            {
                                salePurchaseTaxType = Convert.ToDecimal(12.5);
                            }
                            else if(string.Compare(Convert.ToString(dr["ACNAME"]).TrimEnd(), "PURCHASE - TAX EXEMPTED") == 0)
                            {
                                salePurchaseTaxType = 0;
                            }

                            maxAccountLedgerID++;
                            string accountTypeShortName = Convert.ToString(dr["Actyp"]).TrimEnd();
                            int accountTypeID = context.AccountType.Where(p => p.AccountTypeShortName == accountTypeShortName).FirstOrDefault().AccountTypeID;
                            string accountLedgerCode = "L" + maxAccountLedgerID.ToString().PadLeft(6, '0');
                            string originalAccountLedgerCode = Convert.ToString(dr["ACNO"]).TrimEnd();
                            string originalCreditControlCode = Convert.ToString(dr["Cac"]).TrimEnd();
                            string mappedCreditControlCode = Common.controlCodeMap.Where(q => q.OriginalControlCode == originalCreditControlCode).FirstOrDefault().MappedControlCode;
                            int creditControlCodeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == mappedCreditControlCode).FirstOrDefault().AccountLedgerID;
                            string originalDebitControlCode = Convert.ToString(dr["Cad"]).TrimEnd();
                            string mappedDebitControlCode = Common.controlCodeMap.Where(q => q.OriginalControlCode == originalDebitControlCode).FirstOrDefault().MappedControlCode;
                            int debitControlCodeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == mappedDebitControlCode).FirstOrDefault().AccountLedgerID;
                            Common.accountLedgerCodeMap.Add(new AccountLedgerCodeMap() { OriginalAccountLedgerCode = originalAccountLedgerCode, MappedAccountLedgerCode = accountLedgerCode, AccountLedgerTypeID = accountLedgerTypeID });

                            PharmaDAL.Entity.AccountLedgerMaster newPurchaseLedgerMaster = new PharmaDAL.Entity.AccountLedgerMaster()
                            {
                                AccountLedgerName = Convert.ToString(dr["ACName"]).TrimEnd(),
                                AccountLedgerCode = accountLedgerCode,
                                AccountLedgerTypeId = accountLedgerTypeID,
                                AccountTypeId = accountTypeID,
                                OpeningBalance = Convert.ToDouble(dr["Abop"]),
                                CreditDebit = Convert.ToDouble(dr["Abop"]) > 0 ? Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.D) : Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.C),
                                Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true,
                                CreditControlCodeID = creditControlCodeID,
                                DebitControlCodeID = debitControlCodeID,
                                CreatedBy = "admin",
                                CreatedOn = DateTime.Now,
                                SalePurchaseTaxType = salePurchaseTaxType
                            };

                            listPurchaseLedgerMaster.Add(newPurchaseLedgerMaster);
                        }
                    }

                    context.AccountLedgerMaster.AddRange(listPurchaseLedgerMaster);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertSaleLedgerData()
        {
            try
            {
                string query = "select * from ACM where slcd = '06'";

                DataTable dtSaleLedgerMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.AccountLedgerMaster> listSaleLedgerMaster = new List<PharmaDAL.Entity.AccountLedgerMaster>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var maxAccountLedgerID = context.AccountLedgerMaster.Count();
                    int accountLedgerTypeID = context.AccountLedgerType.Where(p => p.SystemName == PharmaBusinessObjects.Common.Constants.AccountLedgerType.SaleLedger).FirstOrDefault().AccountLedgerTypeID;

                    if (dtSaleLedgerMaster != null && dtSaleLedgerMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtSaleLedgerMaster.Rows)
                        {
                            decimal? salePurchaseTaxType = null;

                            if (string.Compare(Convert.ToString(dr["ACNAME"]).TrimEnd(), "SALE - TAXABLE 5%") == 0)
                            {
                                salePurchaseTaxType = 5;
                            }
                            else if (string.Compare(Convert.ToString(dr["ACNAME"]).TrimEnd(), "SALE - TAXABLE 12.5%") == 0)
                            {
                                salePurchaseTaxType = Convert.ToDecimal(12.5);
                            }
                            else if (string.Compare(Convert.ToString(dr["ACNAME"]).TrimEnd(), "SALE - TAX EXEMPTED") == 0)
                            {
                                salePurchaseTaxType = 0;
                            }

                            maxAccountLedgerID++;
                            string accountTypeShortName = Convert.ToString(dr["Actyp"]).TrimEnd();
                            int accountTypeID = context.AccountType.Where(p => p.AccountTypeShortName == accountTypeShortName).FirstOrDefault().AccountTypeID;
                            string accountLedgerCode = "L" + maxAccountLedgerID.ToString().PadLeft(6, '0');
                            string originalAccountLedgerCode = Convert.ToString(dr["ACNO"]).TrimEnd();
                            string originalCreditControlCode = Convert.ToString(dr["Cac"]).TrimEnd();
                            string mappedCreditControlCode = Common.controlCodeMap.Where(q => q.OriginalControlCode == originalCreditControlCode).FirstOrDefault().MappedControlCode;
                            int creditControlCodeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == mappedCreditControlCode).FirstOrDefault().AccountLedgerID;
                            string originalDebitControlCode = Convert.ToString(dr["Cad"]).TrimEnd();
                            string mappedDebitControlCode = Common.controlCodeMap.Where(q => q.OriginalControlCode == originalDebitControlCode).FirstOrDefault().MappedControlCode;
                            int debitControlCodeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == mappedDebitControlCode).FirstOrDefault().AccountLedgerID;
                            Common.accountLedgerCodeMap.Add(new AccountLedgerCodeMap() { OriginalAccountLedgerCode = originalAccountLedgerCode, MappedAccountLedgerCode = accountLedgerCode, AccountLedgerTypeID = accountLedgerTypeID });

                            PharmaDAL.Entity.AccountLedgerMaster newSaleLedgerMaster = new PharmaDAL.Entity.AccountLedgerMaster()
                            {
                                AccountLedgerName = Convert.ToString(dr["ACName"]).TrimEnd(),
                                AccountLedgerCode = accountLedgerCode,
                                AccountLedgerTypeId = accountLedgerTypeID,
                                AccountTypeId = accountTypeID,
                                OpeningBalance = Convert.ToDouble(dr["Abop"]),
                                CreditDebit = Convert.ToDouble(dr["Abop"]) > 0 ? Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.D) : Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.C),
                                Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true,
                                CreditControlCodeID = creditControlCodeID,
                                DebitControlCodeID = debitControlCodeID,
                                CreatedBy = "admin",
                                CreatedOn = DateTime.Now,
                                SalePurchaseTaxType = salePurchaseTaxType
                            };

                            listSaleLedgerMaster.Add(newSaleLedgerMaster);
                        }
                    }

                    context.AccountLedgerMaster.AddRange(listSaleLedgerMaster);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
