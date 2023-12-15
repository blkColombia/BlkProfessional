using DCL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ItemLedgerEntryFactory : FactoryBase
    {
        public ItemLedgerEntryFactory() { }

        public ItemLedgerEntry Load(ItemLedgerEntry objBan)
        {
            try
            {
                AddParameters(objBan);
                AddCmdParameter("@Action", 0, ParameterDirection.Input);
                ExecuteReader();
                while (Read())
                {
                    objBan = new ItemLedgerEntry(GetDataReader());
                }
                return objBan;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ItemLedgerEntryCollection SelectByParams(ItemLedgerEntry objBan, int Action)
        {
            ItemLedgerEntryCollection Collection = new ItemLedgerEntryCollection();
            try
            {
                AddParameters(objBan);
                AddCmdParameter("@Action", Action, ParameterDirection.Input);
                ExecuteReader();
                while (Read())
                {
                    Collection.Add(new ItemLedgerEntry(GetDataReader()));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return Collection;
        }

        public DataTable SelectTable(ItemLedgerEntry objBan, int Action)
        {
            DataTable dt = new DataTable();
            try
            {
                AddParameters(objBan);
                AddCmdParameter("@Action", Action, ParameterDirection.Input);
                dt = GetDataSet().Tables[0];
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }

        public int InsertarOrUpdate(ItemLedgerEntry objBan, int Action)
        {
            int i;
            try
            {
                AddParameters(objBan);
                AddCmdParameter("@Action", Action, ParameterDirection.Input);
                ExecuteNonQuery();
                i = 1;
            }
            catch (Exception e)
            {
                i = -1;
                throw e;
            }
            return i;
        }

        private void AddParameters(ItemLedgerEntry objBan)
        {
            CreateCommand("Sp_ItemLedgerEntry", true);
            AddCmdParameter("@TimesTamp", objBan.TimesTamp, ParameterDirection.Input);
            AddCmdParameter("@EntryNo", objBan.EntryNo, ParameterDirection.Input);
            AddCmdParameter("@ItemNo", objBan.ItemNo, ParameterDirection.Input);
            AddCmdParameter("@PostingDate", objBan.PostingDate, ParameterDirection.Input);
            AddCmdParameter("@EntryType", objBan.EntryType, ParameterDirection.Input);
            AddCmdParameter("@SourceNo", objBan.SourceNo, ParameterDirection.Input);
            //AddCmdParameter("@DocumentNo", objBan.DocumentNo, ParameterDirection.Input);
            //AddCmdParameter("@Description", objBan.Description, ParameterDirection.Input);
            AddCmdParameter("@LocationCode", objBan.LocationCode, ParameterDirection.Input);
            //AddCmdParameter("@Quantity", objBan.Quantity, ParameterDirection.Input);
            //AddCmdParameter("@RemainingQuantity", objBan.RemainingQuantity, ParameterDirection.Input);
            //AddCmdParameter("@InvoicedQuatity", objBan.InvoicedQuatity, ParameterDirection.Input);
            //AddCmdParameter("@AppliesToEntry", objBan.AppliesToEntry, ParameterDirection.Input);
            //AddCmdParameter("@Open", objBan.Open, ParameterDirection.Input);
            //AddCmdParameter("@GlobalDimension1Code", objBan.GlobalDimension1Code, ParameterDirection.Input);
            AddCmdParameter("@GlobalDimension2Code", objBan.GlobalDimension2Code, ParameterDirection.Input);
            //AddCmdParameter("@Positive", objBan.Positive, ParameterDirection.Input);
            //AddCmdParameter("@SourceType", objBan.SourceType, ParameterDirection.Input);
            //AddCmdParameter("@DropShipment", objBan.DropShipment, ParameterDirection.Input);
            //AddCmdParameter("@TransactionType", objBan.TransactionType, ParameterDirection.Input);
            //AddCmdParameter("@TransportMethod", objBan.TransportMethod, ParameterDirection.Input);
            //AddCmdParameter("@CountryRegionCode", objBan.CountryRegionCode, ParameterDirection.Input);
            //AddCmdParameter("@EntryExitPoint", objBan.EntryExitPoint, ParameterDirection.Input);
            AddCmdParameter("@DocumentDate", objBan.DocumentDate, ParameterDirection.Input);
            //AddCmdParameter("@ExternalDocumentNo", objBan.ExternalDocumentNo, ParameterDirection.Input);
            //AddCmdParameter("@Area", objBan.Area, ParameterDirection.Input);
            //AddCmdParameter("@TransactionSpecification", objBan.TransactionSpecification, ParameterDirection.Input);
            //AddCmdParameter("@NoSeries", objBan.NoSeries, ParameterDirection.Input);
            //AddCmdParameter("@DocumentType", objBan.DocumentType, ParameterDirection.Input);
            //AddCmdParameter("@DocumentLineNo", objBan.DocumentLineNo, ParameterDirection.Input);
            //AddCmdParameter("@JobNo", objBan.JobNo, ParameterDirection.Input);
            //AddCmdParameter("@JobTaskNo", objBan.JobTaskNo, ParameterDirection.Input);
            //AddCmdParameter("@JobPurchase", objBan.JobPurchase, ParameterDirection.Input);
            //AddCmdParameter("@ProdOrderNo", objBan.ProdOrderNo, ParameterDirection.Input);
            //AddCmdParameter("@VariantCode", objBan.VariantCode, ParameterDirection.Input);
            //AddCmdParameter("@QtyPerUnitOfMeasure", objBan.QtyPerUnitOfMeasure, ParameterDirection.Input);
            //AddCmdParameter("@UnitOfMeasureCode", objBan.UnitOfMeasureCode, ParameterDirection.Input);
            //AddCmdParameter("@DerivedFromBlanketOrder", objBan.DerivedFromBlanketOrder, ParameterDirection.Input);
            //AddCmdParameter("@CrossReferenceNo", objBan.CrossReferenceNo, ParameterDirection.Input);
            //AddCmdParameter("@OriginallyOrderedNo", objBan.OriginallyOrderedNo, ParameterDirection.Input);
            //AddCmdParameter("@OriginallyOrderedVarCode", objBan.OriginallyOrderedVarCode, ParameterDirection.Input);
            //AddCmdParameter("@OutofStockSubstitution", objBan.OutofStockSubstitution, ParameterDirection.Input);
            //AddCmdParameter("@ItemCategoryCode", objBan.ItemCategoryCode, ParameterDirection.Input);
            //AddCmdParameter("@Nonstock", objBan.Nonstock, ParameterDirection.Input);
            //AddCmdParameter("@PurchasingCode", objBan.PurchasingCode, ParameterDirection.Input);
            //AddCmdParameter("@ProductGroupCode", objBan.ProductGroupCode, ParameterDirection.Input);
            //AddCmdParameter("@TransferOrderNo", objBan.TransferOrderNo, ParameterDirection.Input);
            //AddCmdParameter("@CompletelyInvoiced", objBan.CompletelyInvoiced, ParameterDirection.Input);
            //AddCmdParameter("@LastInvoiceDate", objBan.LastInvoiceDate, ParameterDirection.Input);
            //AddCmdParameter("@AppliedEntrytoAdjust", objBan.AppliedEntrytoAdjust, ParameterDirection.Input);
            //AddCmdParameter("@Correction", objBan.Correction, ParameterDirection.Input);
            //AddCmdParameter("@ShippedQtyNotReturned", objBan.ShippedQtyNotReturned, ParameterDirection.Input);
            //AddCmdParameter("@ProdOrderLineNo", objBan.ProdOrderLineNo, ParameterDirection.Input);
            //AddCmdParameter("@ProdOrderCompLineNo", objBan.ProdOrderCompLineNo, ParameterDirection.Input);
            //AddCmdParameter("@ServiceOrderNo", objBan.ServiceOrderNo, ParameterDirection.Input);
            //AddCmdParameter("@SerialNo", objBan.SerialNo, ParameterDirection.Input);
            //AddCmdParameter("@LotNo", objBan.LotNo, ParameterDirection.Input);
            //AddCmdParameter("@WarrantyDate", objBan.WarrantyDate, ParameterDirection.Input);
            //AddCmdParameter("@ExpirationDate", objBan.ExpirationDate, ParameterDirection.Input);
            //AddCmdParameter("@ItemTracking", objBan.ItemTracking, ParameterDirection.Input);
            //AddCmdParameter("@ReturnReasonCode", objBan.ReturnReasonCode, ParameterDirection.Input);
            //AddCmdParameter("@ActiveSerial", objBan.ActiveSerial, ParameterDirection.Input);
            //AddCmdParameter("@GlobalDimension3Code", objBan.GlobalDimension3Code, ParameterDirection.Input);
            //AddCmdParameter("@GlobalDimension4Code", objBan.GlobalDimension4Code, ParameterDirection.Input);
            //AddCmdParameter("@GlobalDimension5Code", objBan.GlobalDimension5Code, ParameterDirection.Input);
            //AddCmdParameter("@GlobalDimension6Code", objBan.GlobalDimension6Code, ParameterDirection.Input);
            //AddCmdParameter("@GlobalDimension7Code", objBan.GlobalDimension7Code, ParameterDirection.Input);
            //AddCmdParameter("@RegisterCar", objBan.RegisterCar, ParameterDirection.Input);
            //AddCmdParameter("@ArrivalDate", objBan.ArrivalDate, ParameterDirection.Input);
            AddCmdParameter("@CustomerNo", objBan.CustomerNo, ParameterDirection.Input);
            //AddCmdParameter("@CustomerLoteNumber", objBan.CustomerLoteNumber, ParameterDirection.Input);
            AddCmdParameter("@Terminal", objBan.Terminal, ParameterDirection.Input);
            //AddCmdParameter("@HandlingOpType", objBan.HandlingOpType, ParameterDirection.Input);
            //AddCmdParameter("@OperativeSource", objBan.OperativeSource, ParameterDirection.Input);
            //AddCmdParameter("@CustomerItemNo", objBan.CustomerItemNo, ParameterDirection.Input);
            //AddCmdParameter("@MovementDescription", objBan.MovementDescription, ParameterDirection.Input);
            //AddCmdParameter("@PemexOrderLineNo", objBan.PemexOrderLineNo, ParameterDirection.Input);
            //AddCmdParameter("@DocumentMWONo", objBan.DocumentMWONo, ParameterDirection.Input);
            //AddCmdParameter("@MachineNo", objBan.MachineNo, ParameterDirection.Input);
            //AddCmdParameter("@GenBusPostingGroup", objBan.GenBusPostingGroup, ParameterDirection.Input);
            //AddCmdParameter("@PackingCode", objBan.PackingCode, ParameterDirection.Input);
            //AddCmdParameter("@QtyWeightperPacking", objBan.QtyWeightperPacking, ParameterDirection.Input);
            //AddCmdParameter("@QtyPackingsperPallet", objBan.QtyPackingsperPallet, ParameterDirection.Input);
            //AddCmdParameter("@Pallet", objBan.Pallet, ParameterDirection.Input);
            //AddCmdParameter("@PalletNoConform", objBan.PalletNoConform, ParameterDirection.Input);
            //AddCmdParameter("@Legend", objBan.Legend, ParameterDirection.Input);
            //AddCmdParameter("@NoTalon", objBan.NoTalon, ParameterDirection.Input);
            //AddCmdParameter("@Ingenio", objBan.Ingenio, ParameterDirection.Input);
            //AddCmdParameter("@Zafra", objBan.Zafra, ParameterDirection.Input);
            //AddCmdParameter("@Sugar", objBan.Sugar, ParameterDirection.Input);
            //AddCmdParameter("@BinCode", objBan.BinCode, ParameterDirection.Input);
            //AddCmdParameter("@MotiveNonConformity", objBan.MotiveNonConformity, ParameterDirection.Input);
            //AddCmdParameter("@RecoveryActions", objBan.RecoveryActions, ParameterDirection.Input);
            //AddCmdParameter("@SourceConsumption", objBan.SourceConsumption, ParameterDirection.Input);
            //AddCmdParameter("@TypeConsumption", objBan.TypeConsumption, ParameterDirection.Input);
            //AddCmdParameter("@TypeConsumptionProduction", objBan.TypeConsumptionProduction, ParameterDirection.Input);
            //AddCmdParameter("@Destinationlocationcode", objBan.Destinationlocationcode, ParameterDirection.Input);
            //AddCmdParameter("@User", objBan.User, ParameterDirection.Input);
            //AddCmdParameter("@Worksheetdemand", objBan.Worksheetdemand, ParameterDirection.Input);
            //AddCmdParameter("@InCustomerCharge", objBan.InCustomerCharge, ParameterDirection.Input);
            //AddCmdParameter("@UserNoConform", objBan.UserNoConform, ParameterDirection.Input);
            //AddCmdParameter("@DateNoConform", objBan.DateNoConform, ParameterDirection.Input);
            //AddCmdParameter("@TimeNoConform", objBan.TimeNoConform, ParameterDirection.Input);
            //AddCmdParameter("@UserSpliter", objBan.UserSpliter, ParameterDirection.Input);
            //AddCmdParameter("@DateSpliter", objBan.DateSpliter, ParameterDirection.Input);
            //AddCmdParameter("@TimeSpliter", objBan.TimeSpliter, ParameterDirection.Input);
            //AddCmdParameter("@PalletSourceNo", objBan.PalletSourceNo, ParameterDirection.Input);
            //AddCmdParameter("@StorageDate", objBan.StorageDate, ParameterDirection.Input);
            //AddCmdParameter("@ReferenceMov", objBan.ReferenceMov, ParameterDirection.Input);
            //AddCmdParameter("@ActivityPoS", objBan.ActivityPoS, ParameterDirection.Input);
            //AddCmdParameter("@ItemReturn", objBan.ItemReturn, ParameterDirection.Input);
            //AddCmdParameter("@Finalidad", objBan.Finalidad, ParameterDirection.Input);
            //AddCmdParameter("@LiberadoporCalidad", objBan.LiberadoporCalidad, ParameterDirection.Input);
            //AddCmdParameter("@CambiodeUbicacion", objBan.CambiodeUbicacion, ParameterDirection.Input);
            //AddCmdParameter("@UltimaUbicacion", objBan.UltimaUbicacion, ParameterDirection.Input);
            //AddCmdParameter("@SoloCambiodeUbicacion", objBan.SoloCambiodeUbicacion, ParameterDirection.Input);
            //AddCmdParameter("@SCambiodeUbi", objBan.SCambiodeUbi, ParameterDirection.Input);
            //AddCmdParameter("@Ultima_Ubicacion", objBan.Ultima_Ubicacion, ParameterDirection.Input);
           
        }
    }
}


