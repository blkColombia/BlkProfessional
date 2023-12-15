using System;
using System.Data;


namespace DCL
{
   public class Employees
    {
        #region Propiedades

        public Employees() { }

        public Employees(Int64? _mintEmployeeId,
                        Int64? _mintIdentificationTypeId,
                        String _mstrIdentificationNumber,
                        String _mstrNames,
                        String _mstrLastNames,
                        Int64? _mintChargeId,
                        String _mstrEmail,
                        String _mstrPhoneNumber,
                        Int64? _mintCompanyId,
                        Int64? _mintStatusId,
                        String _mstrDateCreation,
                        Int64? _mintUserCreation,                        
                        String _mstrDateModify,
                        Int64? _mintUserModify
                        )
        {
            mintEmployeeId = _mintEmployeeId;
            mintIdentificationTypeId = _mintIdentificationTypeId;
            mstrIdentificationNumber = _mstrIdentificationNumber;
            mstrNames = _mstrNames;
            mstrLastNames = _mstrLastNames;
            mintChargeId = _mintChargeId;
            mstrEmail = _mstrEmail;
            mstrPhoneNumber = _mstrPhoneNumber;
            mintCompanyId = _mintCompanyId;
            mintStatusId = _mintStatusId;
            mstrDateCreation = _mstrDateCreation;
            mintUserCreation = _mintUserCreation;
            mstrDateModify = _mstrDateModify;
            mintUserModify = _mintUserModify;
        }

        public Employees(IDataRecord obj)
        {
            mintEmployeeId = Convert.ToInt64(obj["EmployeeId"]);
            mintIdentificationTypeId = Convert.ToInt64(obj["IdentificationTypeId"]);
            mstrIdentificationNumber = Convert.ToString(obj["IdentificationNumber"]);
            mstrNames = Convert.ToString(obj["Names"]);
            mstrLastNames = Convert.ToString(obj["LastNames"]);
            mintChargeId = Convert.ToInt64(obj["ChargeId"]);
            mstrEmail = Convert.ToString(obj["Email"]);            
            mstrPhoneNumber = Convert.ToString(obj["PhoneNumber"]);
            mintCompanyId = Convert.ToInt64(obj["CompanyId"]);
            mintStatusId = Convert.ToInt64(obj["StatusId"]);
            mstrDateCreation = Convert.ToString(obj["DateCreation"]);
            mintUserCreation = Convert.ToInt64(obj["UserCreation"]);
            mstrDateModify = Convert.ToString(obj["DateModify"]);
            mintUserModify = Convert.ToInt64(obj["UserModify"]);
        }

        public Employees(DataRow obj)
        {
            mintEmployeeId = Convert.ToInt64(obj["EmployeeId"]);
            mintIdentificationTypeId = Convert.ToInt64(obj["IdentificationTypeId"]);
            mstrIdentificationNumber = Convert.ToString(obj["IdentificationNumber"]);
            mstrNames = Convert.ToString(obj["Names"]);
            mstrLastNames = Convert.ToString(obj["LastNames"]);
            mintChargeId = Convert.ToInt64(obj["ChargeId"]);
            mstrEmail = Convert.ToString(obj["Email"]);
            mstrPhoneNumber = Convert.ToString(obj["PhoneNumber"]);
            mintCompanyId = Convert.ToInt64(obj["CompanyId"]);
            mintStatusId = Convert.ToInt64(obj["StatusId"]);
            mstrDateCreation = Convert.ToString(obj["DateCreation"]);
            mintUserCreation = Convert.ToInt64(obj["UserCreation"]);
            mstrDateModify = Convert.ToString(obj["DateModify"]);
            mintUserModify = Convert.ToInt64(obj["UserModify"]);
        }

        #endregion

        #region Constructores

        Int64? mintEmployeeId = null;
        public Int64? EmployeeId
        {
            get { return mintEmployeeId; }
            set { mintEmployeeId = value; }
        }

        Int64? mintIdentificationTypeId = null;
        public Int64? IdentificationTypeId
        {
            get { return mintIdentificationTypeId; }
            set { mintIdentificationTypeId = value; }
        }

        String mstrIdentificationNumber = null;
        public String IdentificationNumber
        {
            get { return mstrIdentificationNumber; }
            set { mstrIdentificationNumber = value; }
        }

        String mstrNames = null;
        public String Names
        {
            get { return mstrNames; }
            set { mstrNames = value; }
        }

        String mstrLastNames = null;
        public String LastNames
        {
            get { return mstrLastNames; }
            set { mstrLastNames = value; }
        }

        Int64? mintChargeId = null;
        public Int64? ChargeId
        {
            get { return mintChargeId; }
            set { mintChargeId = value; }
        }

        String mstrEmail = null;
        public String Email
        {
            get { return mstrEmail; }
            set { mstrEmail = value; }
        }

        String mstrPhoneNumber = null;
        public String PhoneNumber
        {
            get { return mstrPhoneNumber; }
            set { mstrPhoneNumber = value; }
        }

        Int64? mintCompanyId = null;
        public Int64? CompanyId
        {
            get { return mintCompanyId; }
            set { mintCompanyId = value; }
        }

        Int64? mintStatusId = null;
        public Int64? StatusId
        {
            get { return mintStatusId; }
            set { mintStatusId = value; }
        }


        String mstrDateCreation = null;
        public String DateCreation
        {
            get { return mstrDateCreation; }
            set { mstrDateCreation = value; }
        }

        Int64? mintUserCreation = null;
        public Int64? UserCreation
        {
            get { return mintUserCreation; }
            set { mintUserCreation = value; }
        }

        String mstrDateModify = null;
        public String DateModify
        {
            get { return mstrDateModify; }
            set { mstrDateModify = value; }
        }

        Int64? mintUserModify = null;
        public Int64? UserModify
        {
            get { return mintUserModify; }
            set { mintUserModify = value; }
        }  
        #endregion
    }
}
