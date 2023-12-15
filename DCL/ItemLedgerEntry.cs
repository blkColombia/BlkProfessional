using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCL
{
    public class ItemLedgerEntry
    {
        #region Propiedades

        public ItemLedgerEntry() { }

        public ItemLedgerEntry(   
                                       
                                       Int32? _numId_ItemLedgerEntry,
                                       String _mstrTimesTamp,
                                       String _mstrEntryNo,
                                       String _mstrItemNo,
                                       String _mstrPostingDate,
                                       Int32? _mnumEntryType,
                                       String _mstrSourceNo,
                                       String _mstrDocumentNo,
                                       String _mstrDescription,
                                       String _mstrLocationCode,
                                       String _mstrQuantity,
                                       String _mstrRemainingQuantity,
                                       String _mstrInvoicedQuatity,
                                       Int32? _mnumAppliesToEntry,
                                       String _mstrOpen,
                                       String _mstrGlobalDimension1Code,
                                       String _mstrGlobalDimension2Code,
                                       String _mstrPositive,
                                       Int32? _mnumSourceType,
                                       String _mstrDropShipment,
                                       String _mstrTransactionType,
                                       String _mstrTransportMethod,
                                       String _mstrCountryRegionCode,
                                       String _mstrEntryExitPoint,
                                       String _mstrDocumentDate,
                                       String _mstrExternalDocumentNo,
                                       String _mstrArea,
                                       String _mstrTransactionSpecification,
                                       String _mstrNoSeries,
                                       Int32? _mnumDocumentTypé,
                                       Int32? _mnumDocumentLineNo,
                                       String _mstrJobNo,
                                       String _mstrJobTaskNo,
                                       String _mstrJobPurchase,
                                       String _mstrProdOrderNo,
                                       String _mstrVariantCode,
                                       String _mstrQtyPerUnitOfMeasure,
                                       String _mstrUnitOfMeasureCode,
                                       String _mstrDerivedFromBlanketOrder,
                                       String _mstrCrossReferenceNo,
                                       String _mstrOriginallyOrderedNo,
                                       String _mstrOriginallyOrderedVarCode,
                                       String _mstrOutOfStockSubstitution,
                                       String _mstrItemCategoryCode,
                                       String _mstrNonstock,
                                       String _mstrPurchasingCode,
                                       String _mstrProductGroupCode,
                                       String _mstrTransferOrderNo,
                                       String _mstrCompletelyInvoiced,
                                       String _mstrLastInvoiceDate,
                                       String _mstrAppliedEntrytoAdjust,
                                       String _mstrCorrection,
                                       String _mstrShippedQtyNotReturned,
                                       Int32? _mnumProdOrderLineNo,
                                       Int32? _mnumProdOrderCompLineNo,
                                       String _mstrServiceOrderNo,
                                       String _mstrSerialNo,
                                       String _mstrLotNo,
                                       String _mstrWarrantyDate,
                                       String _mstrExpirationDate,
                                       Int32? _mnumItemTracking,
                                       String _mstrReturnReasonCode,
                                       String _mstrActiveSerial,
                                       String _mstrGlobalDimension3Code,
                                       String _mstrGlobalDimension4Code,
                                       String _mstrGlobalDimension5Code,
                                       String _mstrGlobalDimension6Code,
                                       String _mstrGlobalDimension7Code,
                                       String _mstrRegisterCar,
                                       String _mstrArrivalDate,
                                       String _mstrCustomerNo,
                                       String _mstrCustomerLoteNumber,
                                       String _mstrTerminal,
                                       String _mstrHandlingOpType,
                                       Int32? _mstrOperativeSource,
                                       String _mstrCustomerItemNo,
                                       String _mstrMovementDescription,
                                       String _mstrPemexOrderLineNo,
                                       String _mstrDocumentMWONo,
                                       String _mstrMachineNo,
                                       String _mstrGenBusPostingGroup,
                                       String _mstrPackingCode,
                                       String _mstrQtyWeightperPacking,
                                       String _mstrQtyPackingsperPallet,
                                       String _mstrPallet,
                                       String _mstrPalletNoConform,
                                       String _mstrLegend,
                                       String _mstrNoTalon,
                                       String _mstrIngenio,
                                       String _mstrZafra,
                                       String _mstrSugar,
                                       String _mstrBinCode,
                                       String _mstrMotiveNonConformity,
                                       String _mstrRecoveryActions,
                                       Int32? _mnumSourceConsumption,
                                       Int32? _mnumTypeConsumption,
                                       Int32? _mnumTypeConsumptionProduction,
                                       String _mstrDestinationlocationcode,
                                       String _mstrUser,
                                       String _mstrWorksheetdemand,
                                       String _mstrInCustomerCharge,
                                       String _mstrUserNoConform,
                                       String _mstrDateNoConform,
                                       String _mstrTimeNoConform,
                                       String _mstrSplitPallet,
                                       String _mstrUserSpliter,
                                       String _mstrDateSpliter,
                                       String _mstrTimeSpliter,
                                       String _mstrPalletSourceNo,
                                       String _mstrStorageDate,
                                       String _mstrReferenceMov,
                                       String _mstrActivityPoS,
                                       String _mstrItemReturn,
                                       Int32? _mnumFinalidad,
                                       String _mstrLiberadoporCalidad,
                                       String _mstrCambiodeUbicacion,
                                       String _mstrUltimaUbicacion,
                                       String _mstrSoloCambiodeUbicacion,
                                       String _mstrSCambiodeUbi,
                                       String _mstrUltima_Ubicacion                                       
                                )
        {
            mnumId_ItemLedgerEntry = _numId_ItemLedgerEntry;
            mstrTimesTamp = _mstrTimesTamp;
            mstrEntryNo = _mstrEntryNo;
            mstrItemNo = _mstrItemNo;
            mstrPostingDate = _mstrPostingDate;
            mnumEntryType = _mnumEntryType;
            mstrSourceNo = _mstrSourceNo;
            mstrDocumentNo = _mstrDocumentNo;
            mstrDescription = _mstrDescription;
            mstrLocationCode = _mstrLocationCode;
            mstrQuantity = _mstrQuantity;
            mstrRemainingQuantity = _mstrRemainingQuantity;
            mstrInvoicedQuatity = _mstrInvoicedQuatity;
            mnumAppliesToEntry = _mnumAppliesToEntry;
            mstrOpen = _mstrOpen;
            mstrGlobalDimension1Code = _mstrGlobalDimension1Code;
            mstrGlobalDimension2Code = _mstrGlobalDimension2Code;
            mstrPositive = _mstrPositive;
            mnumSourceType = _mnumSourceType;
            mstrDropShipment = _mstrDropShipment;
            mstrTransactionType = _mstrTransactionType;
            mstrTransportMethod = _mstrTransportMethod;
            mstrCountryRegionCode = _mstrCountryRegionCode;
            mstrEntryExitPoint = _mstrEntryExitPoint;
            mstrDocumentDate = _mstrDocumentDate;
            mstrExternalDocumentNo = _mstrExternalDocumentNo;
            mstrArea = _mstrArea;
            mstrTransactionSpecification = _mstrTransactionSpecification;
            mstrNoSeries = _mstrNoSeries;
            mnumDocumentType = _mnumDocumentTypé;
            mnumDocumentLineNo = _mnumDocumentLineNo;
            mstrJobNo = _mstrJobNo;
            mstrJobTaskNo = _mstrJobTaskNo;
            mstrJobPurchase = _mstrJobPurchase;
            mstrProdOrderNo = _mstrProdOrderNo;
            mstrVariantCode = _mstrVariantCode;
            mstrQtyPerUnitOfMeasure = _mstrQtyPerUnitOfMeasure;
            mstrUnitOfMeasureCode = _mstrUnitOfMeasureCode;
            mstrDerivedFromBlanketOrder = _mstrDerivedFromBlanketOrder;
            mstrCrossReferenceNo = _mstrCrossReferenceNo;
            mstrOriginallyOrderedNo = _mstrOriginallyOrderedNo;
            mstrOriginallyOrderedVarCode = _mstrOriginallyOrderedVarCode;
            mstrOutOfStockSubstitution = _mstrOutOfStockSubstitution;
            mstrItemCategoryCode = _mstrItemCategoryCode;
            mstrNonstock = _mstrNonstock;
            mstrPurchasingCode = _mstrPurchasingCode;
            mstrProductGroupCode = _mstrProductGroupCode;
            mstrTransferOrderNo = _mstrTransferOrderNo;
            mstrCompletelyInvoiced = _mstrCompletelyInvoiced;
            mstrLastInvoiceDate = _mstrLastInvoiceDate;
            mstrAppliedEntrytoAdjust = _mstrAppliedEntrytoAdjust;
            mstrCorrection = _mstrCorrection;
            mstrShippedQtyNotReturned = _mstrShippedQtyNotReturned;
            mnumProdOrderLineNo = _mnumProdOrderLineNo;
            mnumProdOrderCompLineNo = _mnumProdOrderCompLineNo;
            mstrServiceOrderNo = _mstrServiceOrderNo;
            mstrSerialNo = _mstrSerialNo;
            mstrLotNo = _mstrLotNo;
            mstrWarrantyDate = _mstrWarrantyDate;
            mstrExpirationDate = _mstrExpirationDate;
            mnumItemTracking = _mnumItemTracking;
            mstrReturnReasonCode = _mstrReturnReasonCode;
            mstrActiveSerial = _mstrActiveSerial;
            mstrGlobalDimension3Code = _mstrGlobalDimension3Code;
            mstrGlobalDimension4Code = _mstrGlobalDimension4Code;
            mstrGlobalDimension5Code = _mstrGlobalDimension5Code;
            mstrGlobalDimension6Code = _mstrGlobalDimension6Code;
            mstrGlobalDimension7Code = _mstrGlobalDimension7Code;
            mstrRegisterCar = _mstrRegisterCar;
            mstrArrivalDate = _mstrArrivalDate;
            mstrCustomerNo = _mstrCustomerNo;
            mstrCustomerLoteNumber = _mstrCustomerLoteNumber;
            mstrTerminal = _mstrTerminal;
            mstrHandlingOpType = _mstrHandlingOpType;
            mstrOperativeSource = _mstrOperativeSource;
            mstrCustomerItemNo = _mstrCustomerItemNo;
            mstrMovementDescription = _mstrMovementDescription;
            mstrPemexOrderLineNo = _mstrPemexOrderLineNo;
            mstrDocumentMWONo = _mstrDocumentMWONo;
            mstrMachineNo = _mstrMachineNo;
            mstrGenBusPostingGroup = _mstrGenBusPostingGroup;
            mstrPackingCode = _mstrPackingCode;
            mstrQtyWeightperPacking = _mstrQtyWeightperPacking;
            mstrQtyPackingsperPallet = _mstrQtyPackingsperPallet;
            mstrPallet = _mstrPallet;
            mstrPalletNoConform = _mstrPalletNoConform;
            mstrLegend = _mstrLegend;
            mstrNoTalon = _mstrNoTalon;
            mstrIngenio = _mstrIngenio;
            mstrZafra = _mstrZafra;
            mstrSugar = _mstrSugar;
            mstrBinCode = _mstrBinCode;
            mstrMotiveNonConformity = _mstrMotiveNonConformity;
            mstrRecoveryActions = _mstrRecoveryActions;
            mnumSourceConsumption = _mnumSourceConsumption;
            mnumTypeConsumption = _mnumTypeConsumption;
            mnumTypeConsumptionProduction = _mnumTypeConsumptionProduction;
            mstrDestinationlocationcode = _mstrDestinationlocationcode;
            mstrUser = _mstrUser;
            mstrWorksheetdemand = _mstrWorksheetdemand;
            mstrInCustomerCharge = _mstrInCustomerCharge;
            mstrUserNoConform = _mstrUserNoConform;
            mstrDateNoConform = _mstrDateNoConform;
            mstrTimeNoConform = _mstrTimeNoConform;
            mstrSplitPallet = _mstrSplitPallet;
            mstrUserSpliter = _mstrUserSpliter;
            mstrDateSpliter = _mstrDateSpliter;
            mstrTimeSpliter = _mstrTimeSpliter;
            mstrPalletSourceNo = _mstrPalletSourceNo;
            mstrStorageDate = _mstrStorageDate;
            mstrReferenceMov = _mstrReferenceMov;
            mstrActivityPoS = _mstrActivityPoS;
            mstrItemReturn = _mstrItemReturn;
            mnumFinalidad = _mnumFinalidad;
            mstrLiberadoporCalidad = _mstrLiberadoporCalidad;
            mstrCambiodeUbicacion = _mstrCambiodeUbicacion;
            mstrUltimaUbicacion = _mstrUltimaUbicacion;
            mstrSoloCambiodeUbicacion = _mstrSoloCambiodeUbicacion;
            mstrSCambiodeUbi = _mstrSCambiodeUbi;
            mstrUltima_Ubicacion = _mstrUltima_Ubicacion;



        }

        public ItemLedgerEntry(IDataRecord obj)
        {
            mnumId_ItemLedgerEntry = Convert.ToInt32(obj["Id_ItemLedgerEntry"]);
            mstrTimesTamp = Convert.ToString(obj["timestamp"]);
            mstrEntryNo = Convert.ToString(obj["Entry No_"]);
            mstrItemNo = Convert.ToString(obj["Item No_"]);
            mstrPostingDate = Convert.ToString(obj["Posting Date"]);
            mnumEntryType = Convert.ToInt32(obj["Entry Type"]);
            mstrSourceNo = Convert.ToString(obj["Source No_"]);
            mstrDocumentNo = Convert.ToString(obj["Document No_"]);
            mstrDescription = Convert.ToString(obj["Description"]);
            mstrLocationCode = Convert.ToString(obj["Location Code"]);
            mstrQuantity = Convert.ToString(obj["Quantity"]);
            mstrRemainingQuantity = Convert.ToString(obj["Remaining Quantity"]);
            mstrInvoicedQuatity = Convert.ToString(obj["Invoiced Quantity"]);
            mnumAppliesToEntry = Convert.ToInt32(obj["Applies-to Entry"]);
            mstrOpen = Convert.ToString(obj["Open"]);
            mstrGlobalDimension1Code = Convert.ToString(obj["Global Dimension 1 Code"]);
            mstrGlobalDimension2Code = Convert.ToString(obj["Global Dimension 2 Code"]);
            mstrPositive = Convert.ToString(obj["Positive"]);
            mnumSourceType = Convert.ToInt32(obj["Source Type"]);
            mstrDropShipment = Convert.ToString(obj["Drop Shipment"]);
            mstrTransactionType = Convert.ToString(obj["Transaction Type"]);
            mstrTransportMethod = Convert.ToString(obj["Transport Method"]);
            mstrCountryRegionCode = Convert.ToString(obj["Country_Region Code"]);
            mstrEntryExitPoint = Convert.ToString(obj["Entry_Exit Point"]);
            mstrDocumentDate = Convert.ToString(obj["Document Date"]);
            mstrExternalDocumentNo = Convert.ToString(obj["External Document No_"]);
            mstrArea = Convert.ToString(obj["Area"]);
            mstrTransactionSpecification = Convert.ToString(obj["Transaction Specification"]);
            mstrNoSeries = Convert.ToString(obj["No_ Series"]);
            mnumDocumentType = Convert.ToInt32(obj["Document Type"]);
            mnumDocumentLineNo = Convert.ToInt32(obj["Document Line No_"]);
            mstrJobNo = Convert.ToString(obj["Job No_"]);
            mstrJobTaskNo = Convert.ToString(obj["Job Task No_"]);
            mstrJobPurchase = Convert.ToString(obj["Job Purchase"]);
            mstrProdOrderNo = Convert.ToString(obj["Prod_ Order No_"]);
            mstrVariantCode = Convert.ToString(obj["Prod_ Order No_"]);
            mstrQtyPerUnitOfMeasure = Convert.ToString(obj["Qty_ per Unit of Measure"]);
            mstrUnitOfMeasureCode = Convert.ToString(obj["Unit of Measure Code"]);
            mstrDerivedFromBlanketOrder = Convert.ToString(obj["Derived from Blanket Order"]);
            mstrCrossReferenceNo = Convert.ToString(obj["Cross-Reference No_"]);
            mstrOriginallyOrderedNo = Convert.ToString(obj["Originally Ordered No_"]);
            mstrOriginallyOrderedVarCode = Convert.ToString(obj["Originally Ordered Var_ Code"]);
            mstrOutOfStockSubstitution = Convert.ToString(obj["Out-of-Stock Substitution"]);
            mstrItemCategoryCode = Convert.ToString(obj["Item Category Code"]);
            mstrNonstock = Convert.ToString(obj["Nonstock"]);
            mstrPurchasingCode = Convert.ToString(obj["Purchasing Code"]);
            mstrProductGroupCode = Convert.ToString(obj["Product Group Code"]);
            mstrTransferOrderNo = Convert.ToString(obj["Transfer Order No_"]);
            mstrCompletelyInvoiced = Convert.ToString(obj["Completely Invoiced"]);
            mstrLastInvoiceDate = Convert.ToString(obj["Last Invoice Date"]);
            mstrAppliedEntrytoAdjust = Convert.ToString(obj["Applied Entry to Adjust"]);
            mstrCorrection = Convert.ToString(obj["Correction"]);
            mstrShippedQtyNotReturned = Convert.ToString(obj["Shipped Qty_ Not Returned"]);
            mnumProdOrderLineNo = Convert.ToInt32(obj["Prod_ Order Line No_"]);
            mnumProdOrderCompLineNo = Convert.ToInt32(obj["Prod_ Order Comp_ Line No_"]);
            mstrServiceOrderNo = Convert.ToString(obj["Service Order No_"]);
            mstrSerialNo = Convert.ToString(obj["Serial No_"]);
            mstrLotNo = Convert.ToString(obj["Lot No_"]);
            mstrWarrantyDate = Convert.ToString(obj["Warranty Date"]);
            mstrExpirationDate = Convert.ToString(obj["Expiration Date"]);
            mnumItemTracking = Convert.ToInt32(obj["Item Tracking"]);
            mstrReturnReasonCode = Convert.ToString(obj["Return Reason Code"]);
            mstrActiveSerial = Convert.ToString(obj["Active Serial"]);
            mstrGlobalDimension3Code = Convert.ToString(obj["Global Dimension 3 Code"]);
            mstrGlobalDimension4Code = Convert.ToString(obj["Global Dimension 4 Code"]);
            mstrGlobalDimension5Code = Convert.ToString(obj["Global Dimension 5 Code"]);
            mstrGlobalDimension6Code = Convert.ToString(obj["Global Dimension 6 Code"]);
            mstrGlobalDimension7Code = Convert.ToString(obj["Global Dimension 7 Code"]);
            mstrRegisterCar = Convert.ToString(obj["Register Car"]);
            mstrArrivalDate = Convert.ToString(obj["Arrival Date"]);
            mstrCustomerNo = Convert.ToString(obj["Customer No_"]);
            mstrCustomerLoteNumber = Convert.ToString(obj["Customer Lote Number"]);
            mstrTerminal = Convert.ToString(obj["Terminal"]);
            mstrHandlingOpType = Convert.ToString(obj["Handling Op_ Type"]);
            mstrOperativeSource = Convert.ToInt32(obj["Operative Source"]);
            mstrCustomerItemNo = Convert.ToString(obj["Customer Item No_"]);
            mstrMovementDescription = Convert.ToString(obj["Movement Description"]);
            mstrPemexOrderLineNo = Convert.ToString(obj["Pemex Order Line No_"]);
            mstrDocumentMWONo = Convert.ToString(obj["Document MWO No_"]);
            mstrMachineNo = Convert.ToString(obj["Machine No_"]);
            mstrGenBusPostingGroup = Convert.ToString(obj["Gen_ Bus_ Posting Group"]);
            mstrPackingCode = Convert.ToString(obj["Packing Code"]);
            mstrQtyWeightperPacking = Convert.ToString(obj["Qty_ Weight per Packing"]);
            mstrQtyPackingsperPallet = Convert.ToString(obj["Qty_ Packings per Pallet"]);
            mstrPallet = Convert.ToString(obj["Pallet"]);
            mstrPalletNoConform = Convert.ToString(obj["Pallet NoConform"]);
            mstrLegend = Convert.ToString(obj["Legend"]);
            mstrNoTalon = Convert.ToString(obj["No_ Talon"]);
            mstrIngenio = Convert.ToString(obj["Ingenio"]);
            mstrZafra = Convert.ToString(obj["Zafra"]);
            mstrSugar = Convert.ToString(obj["Sugar"]);
            mstrBinCode = Convert.ToString(obj["Bin Code"]);
            mstrMotiveNonConformity = Convert.ToString(obj["Motive NonConformity"]);
            mstrRecoveryActions = Convert.ToString(obj["Recovery Actions"]);
            mnumSourceConsumption = Convert.ToInt32(obj["Source Consumption"]);
            mnumTypeConsumption = Convert.ToInt32(obj["Type Consumption"]);
            mnumTypeConsumptionProduction = Convert.ToInt32(obj["Type Consumption Production"]);
            mstrDestinationlocationcode = Convert.ToString(obj["Destination location code"]);
            mstrUser = Convert.ToString(obj["User"]);
            mstrWorksheetdemand = Convert.ToString(obj["Worksheet demand"]);
            mstrInCustomerCharge = Convert.ToString(obj["In Customer Charge"]);
            mstrUserNoConform = Convert.ToString(obj["User NoConform"]);
            mstrDateNoConform = Convert.ToString(obj["Date NoConform"]);
            mstrTimeNoConform = Convert.ToString(obj["Time NoConform"]);
            mstrSplitPallet = Convert.ToString(obj["Split Pallet"]);
            mstrUserSpliter = Convert.ToString(obj["User Spliter"]);
            mstrDateSpliter = Convert.ToString(obj["Date Spliter"]);
            mstrTimeSpliter = Convert.ToString(obj["Time Spliter"]);
            mstrPalletSourceNo = Convert.ToString(obj["Pallet Source No_"]);
            mstrStorageDate = Convert.ToString(obj["Storage Date"]);
            mstrReferenceMov = Convert.ToString(obj["Reference Mov"]);
            mstrActivityPoS = Convert.ToString(obj["Activity _ PoS"]);
            mstrItemReturn = Convert.ToString(obj["Item Return"]);
            mnumFinalidad = Convert.ToInt32(obj["Finalidad"]);
            mstrLiberadoporCalidad = Convert.ToString(obj["Liberado por Calidad"]);
            mstrCambiodeUbicacion = Convert.ToString(obj["Cambio de Ubicacion"]);
            mstrUltimaUbicacion = Convert.ToString(obj["Ultima Ubicacion"]);
            mstrSoloCambiodeUbicacion = Convert.ToString(obj["Solo Cambio de Ubicacion"]);
            mstrSCambiodeUbi = Convert.ToString(obj["S_Cambio de Ubi"]);
            mstrUltima_Ubicacion = Convert.ToString(obj["Ultima_Ubicacion"]);
        }

        public ItemLedgerEntry(DataRow obj)
        {
            mnumId_ItemLedgerEntry = Convert.ToInt32(obj["Id_ItemLedgerEntry"]);
            mstrTimesTamp = Convert.ToString(obj["timestamp"]);
            mstrEntryNo = Convert.ToString(obj["Entry No_"]);
            mstrItemNo = Convert.ToString(obj["Item No_"]);
            mstrPostingDate = Convert.ToString(obj["Posting Date"]);
            mnumEntryType = Convert.ToInt32(obj["Entry Type"]);
            mstrSourceNo = Convert.ToString(obj["Source No_"]);
            mstrDocumentNo = Convert.ToString(obj["Document No_"]);
            mstrDescription = Convert.ToString(obj["Description"]);
            mstrLocationCode = Convert.ToString(obj["Location Code"]);
            mstrQuantity = Convert.ToString(obj["Quantity"]);
            mstrQuantity = Convert.ToString(obj["Quantity"]);
            mstrRemainingQuantity = Convert.ToString(obj["Remaining Quantity"]);
            mstrInvoicedQuatity = Convert.ToString(obj["Invoiced Quantity"]);
            mnumAppliesToEntry = Convert.ToInt32(obj["Applies-to Entry"]);
            mstrOpen = Convert.ToString(obj["Open"]);
            mstrGlobalDimension1Code = Convert.ToString(obj["Global Dimension 1 Code"]);
            mstrGlobalDimension2Code = Convert.ToString(obj["Global Dimension 2 Code"]);
            mstrPositive = Convert.ToString(obj["Positive"]);
            mnumSourceType = Convert.ToInt32(obj["Source Type"]);
            mstrDropShipment = Convert.ToString(obj["Drop Shipment"]);
            mstrTransactionType = Convert.ToString(obj["Transaction Type"]);
            mstrTransportMethod = Convert.ToString(obj["Transport Method"]);
            mstrCountryRegionCode = Convert.ToString(obj["Country_Region Code"]);
            mstrEntryExitPoint = Convert.ToString(obj["Entry_Exit Point"]);
            mstrDocumentDate = Convert.ToString(obj["Document Date"]);
            mstrExternalDocumentNo = Convert.ToString(obj["External Document No_"]);
            mstrArea = Convert.ToString(obj["Area"]);
            mstrTransactionSpecification = Convert.ToString(obj["Transaction Specification"]);
            mstrNoSeries = Convert.ToString(obj["No_ Series"]);
            mnumDocumentType = Convert.ToInt32(obj["Document Type"]);
            mnumDocumentLineNo = Convert.ToInt32(obj["Document Line No_"]);
            mstrJobNo = Convert.ToString(obj["Job No_"]);
            mstrJobTaskNo = Convert.ToString(obj["Job Task No_"]);
            mstrJobPurchase = Convert.ToString(obj["Job Purchase"]);
            mstrProdOrderNo = Convert.ToString(obj["Prod_ Order No_"]);
            mstrVariantCode = Convert.ToString(obj["Prod_ Order No_"]);
            mstrQtyPerUnitOfMeasure = Convert.ToString(obj["Qty_ per Unit of Measure"]);
            mstrUnitOfMeasureCode = Convert.ToString(obj["Unit of Measure Code"]);
            mstrDerivedFromBlanketOrder = Convert.ToString(obj["Derived from Blanket Order"]);
            mstrCrossReferenceNo = Convert.ToString(obj["Cross-Reference No_"]);
            mstrOriginallyOrderedNo = Convert.ToString(obj["Originally Ordered No_"]);
            mstrOriginallyOrderedVarCode = Convert.ToString(obj["Originally Ordered Var_ Code"]);
            mstrOutOfStockSubstitution = Convert.ToString(obj["Out-of-Stock Substitution"]);
            mstrItemCategoryCode = Convert.ToString(obj["Item Category Code"]);
            mstrNonstock = Convert.ToString(obj["Nonstock"]);
            mstrPurchasingCode = Convert.ToString(obj["Purchasing Code"]);
            mstrProductGroupCode = Convert.ToString(obj["Product Group Code"]);
            mstrTransferOrderNo = Convert.ToString(obj["Transfer Order No_"]);
            mstrCompletelyInvoiced = Convert.ToString(obj["Completely Invoiced"]);
            mstrLastInvoiceDate = Convert.ToString(obj["Last Invoice Date"]);
            mstrAppliedEntrytoAdjust = Convert.ToString(obj["Applied Entry to Adjust"]);
            mstrCorrection = Convert.ToString(obj["Correction"]);
            mstrShippedQtyNotReturned = Convert.ToString(obj["Shipped Qty_ Not Returned"]);
            mnumProdOrderLineNo = Convert.ToInt32(obj["Prod_ Order Line No_"]);
            mnumProdOrderCompLineNo = Convert.ToInt32(obj["Prod_ Order Comp_ Line No_"]);
            mstrServiceOrderNo = Convert.ToString(obj["Service Order No_"]);
            mstrSerialNo = Convert.ToString(obj["Serial No_"]);
            mstrLotNo = Convert.ToString(obj["Lot No_"]);
            mstrWarrantyDate = Convert.ToString(obj["Warranty Date"]);
            mstrExpirationDate = Convert.ToString(obj["Expiration Date"]);
            mnumItemTracking = Convert.ToInt32(obj["Item Tracking"]);
            mstrReturnReasonCode = Convert.ToString(obj["Return Reason Code"]);
            mstrActiveSerial = Convert.ToString(obj["Active Serial"]);
            mstrGlobalDimension3Code = Convert.ToString(obj["Global Dimension 3 Code"]);
            mstrGlobalDimension4Code = Convert.ToString(obj["Global Dimension 4 Code"]);
            mstrGlobalDimension5Code = Convert.ToString(obj["Global Dimension 5 Code"]);
            mstrGlobalDimension6Code = Convert.ToString(obj["Global Dimension 6 Code"]);
            mstrGlobalDimension7Code = Convert.ToString(obj["Global Dimension 7 Code"]);
            mstrRegisterCar = Convert.ToString(obj["Register Car"]);
            mstrArrivalDate = Convert.ToString(obj["Arrival Date"]);
            mstrCustomerNo = Convert.ToString(obj["Customer No_"]);
            mstrCustomerLoteNumber = Convert.ToString(obj["Customer Lote Number"]);
            mstrTerminal = Convert.ToString(obj["Terminal"]);
            mstrHandlingOpType = Convert.ToString(obj["Handling Op_ Type"]);
            mstrOperativeSource = Convert.ToInt32(obj["Operative Source"]);
            mstrCustomerItemNo = Convert.ToString(obj["Customer Item No_"]);
            mstrMovementDescription = Convert.ToString(obj["Movement Description"]);
            mstrPemexOrderLineNo = Convert.ToString(obj["Pemex Order Line No_"]);
            mstrDocumentMWONo = Convert.ToString(obj["Document MWO No_"]);
            mstrMachineNo = Convert.ToString(obj["Machine No_"]);
            mstrGenBusPostingGroup = Convert.ToString(obj["Gen_ Bus_ Posting Group"]);
            mstrPackingCode = Convert.ToString(obj["Packing Code"]);
            mstrQtyWeightperPacking = Convert.ToString(obj["Qty_ Weight per Packing"]);
            mstrQtyPackingsperPallet = Convert.ToString(obj["Qty_ Packings per Pallet"]);
            mstrPallet = Convert.ToString(obj["Pallet"]);
            mstrPalletNoConform = Convert.ToString(obj["Pallet NoConform"]);
            mstrLegend = Convert.ToString(obj["Legend"]);
            mstrNoTalon = Convert.ToString(obj["No_ Talon"]);
            mstrIngenio = Convert.ToString(obj["Ingenio"]);
            mstrZafra = Convert.ToString(obj["Zafra"]);
            mstrSugar = Convert.ToString(obj["Sugar"]);
            mstrBinCode = Convert.ToString(obj["Bin Code"]);
            mstrMotiveNonConformity = Convert.ToString(obj["Motive NonConformity"]);
            mstrRecoveryActions = Convert.ToString(obj["Recovery Actions"]);
            mnumSourceConsumption = Convert.ToInt32(obj["Source Consumption"]);
            mnumTypeConsumption = Convert.ToInt32(obj["Type Consumption"]);
            mnumTypeConsumptionProduction = Convert.ToInt32(obj["Type Consumption Production"]);
            mstrDestinationlocationcode = Convert.ToString(obj["Destination location code"]);
            mstrUser = Convert.ToString(obj["User"]);
            mstrWorksheetdemand = Convert.ToString(obj["Worksheet demand"]);
            mstrInCustomerCharge = Convert.ToString(obj["In Customer Charge"]);
            mstrUserNoConform = Convert.ToString(obj["User NoConform"]);
            mstrDateNoConform = Convert.ToString(obj["Date NoConform"]);
            mstrTimeNoConform = Convert.ToString(obj["Time NoConform"]);
            mstrSplitPallet = Convert.ToString(obj["Split Pallet"]);
            mstrUserSpliter = Convert.ToString(obj["User Spliter"]);
            mstrDateSpliter = Convert.ToString(obj["Date Spliter"]);
            mstrTimeSpliter = Convert.ToString(obj["Time Spliter"]);
            mstrPalletSourceNo = Convert.ToString(obj["Pallet Source No_"]);
            mstrStorageDate = Convert.ToString(obj["Storage Date"]);
            mstrReferenceMov = Convert.ToString(obj["Reference Mov"]);
            mstrActivityPoS = Convert.ToString(obj["Activity _ PoS"]);
            mstrItemReturn = Convert.ToString(obj["Item Return"]);
            mnumFinalidad = Convert.ToInt32(obj["Finalidad"]);
            mstrLiberadoporCalidad = Convert.ToString(obj["Liberado por Calidad"]);
            mstrCambiodeUbicacion = Convert.ToString(obj["Cambio de Ubicacion"]);
            mstrUltimaUbicacion = Convert.ToString(obj["Ultima Ubicacion"]);
            mstrSoloCambiodeUbicacion = Convert.ToString(obj["Solo Cambio de Ubicacion"]);
            mstrSCambiodeUbi = Convert.ToString(obj["S_Cambio de Ubi"]);
            mstrUltima_Ubicacion = Convert.ToString(obj["Ultima_Ubicacion"]);

        }

        #endregion

        #region Constructores

        Int32? mnumId_ItemLedgerEntry = null;
        public Int32? Id_ItemLedgerEntry
        {
            get { return mnumId_ItemLedgerEntry; }
            set { mnumId_ItemLedgerEntry = value; }
        }

        String mstrTimesTamp = null;
        public String TimesTamp
        {
            get { return mstrTimesTamp; }
            set { mstrTimesTamp = value; }
        }

        String mstrEntryNo = null;
        public String EntryNo
        {
            get { return mstrEntryNo; }
            set { mstrEntryNo = value; }
        }

        String mstrItemNo = null;
        public String ItemNo
        {
            get { return mstrItemNo; }
            set { mstrItemNo = value; }
        }

        String mstrPostingDate = null;
        public String PostingDate
        {
            get { return mstrPostingDate; }
            set { mstrPostingDate = value; }
        }


        Int32? mnumEntryType = null;
        public Int32? EntryType
        {
            get { return mnumEntryType; }
            set { mnumEntryType = value; }
        }

        String mstrSourceNo = null;
        public String SourceNo
        {
            get { return mstrSourceNo; }
            set { mstrSourceNo = value; }
        }


        String mstrDocumentNo = null;
        public String DocumentNo
        {
            get { return mstrDocumentNo; }
            set { mstrDocumentNo = value; }
        }


        String mstrDescription = null;
        public String Description
        {
            get { return mstrDescription; }
            set { mstrDescription = value; }
        }


        String mstrLocationCode = null;
        public String LocationCode
        {
            get { return mstrLocationCode; }
            set { mstrLocationCode = value; }
        }


        String mstrQuantity = null;
        public String Quantity
        {
            get { return mstrQuantity; }
            set { mstrQuantity = value; }
        }

        String mstrRemainingQuantity = null;
        public String RemainingQuantity
        {
            get { return mstrRemainingQuantity; }
            set { mstrRemainingQuantity = value; }
        }

        String mstrInvoicedQuatity = null;
        public String InvoicedQuatity
        {
            get { return mstrInvoicedQuatity; }
            set { mstrInvoicedQuatity = value; }
        }

        Int32? mnumAppliesToEntry = null;
        public Int32? AppliesToEntry
        {
            get { return mnumAppliesToEntry; }
            set { mnumAppliesToEntry = value; }
        }

        String mstrOpen = null;
        public String Open
        {
            get { return mstrOpen; }
            set { mstrOpen = value; }
        }
        String mstrGlobalDimension1Code = null;
        public String GlobalDimension1Code
        {
            get { return mstrGlobalDimension1Code; }
            set { mstrGlobalDimension1Code = value; }
        }
        String mstrGlobalDimension2Code = null;
        public String GlobalDimension2Code
        {
            get { return mstrGlobalDimension2Code; }
            set { mstrGlobalDimension1Code = value; }
        }
        String mstrPositive = null;
        public String Positive
        {
            get { return mstrPositive; }
            set { mstrPositive = value; }
        }
        Int32? mnumSourceType = null;
        public Int32? SourceType
        {
            get { return mnumSourceType; }
            set { mnumSourceType = value; }
        }
        String mstrDropShipment = null;
        public String DropShipment
        {
            get { return mstrDropShipment; }
            set { mstrDropShipment = value; }
        }
        String mstrTransactionType = null;
        public String TransactionType
        {
            get { return mstrTransactionType; }
            set { mstrTransactionType = value; }
        }
        String mstrTransportMethod = null;
        public String TransportMethod
        {
            get { return mstrTransportMethod; }
            set { mstrTransportMethod = value; }
        }

        String mstrCountryRegionCode = null;
        public String CountryRegionCode
        {
            get { return mstrCountryRegionCode; }
            set { mstrCountryRegionCode = value; }
        }
        String mstrEntryExitPoint = null;
        public String EntryExitPoint
        {
            get { return mstrEntryExitPoint; }
            set { mstrEntryExitPoint = value; }
        }
        String mstrDocumentDate = null;
        public String DocumentDate
        {
            get { return mstrDocumentDate; }
            set { mstrDocumentDate = value; }
        }
        String mstrExternalDocumentNo = null;
        public String ExternalDocumentNo
        {
            get { return mstrExternalDocumentNo; }
            set { mstrExternalDocumentNo = value; }
        }
        String mstrArea = null;
        public String Area
        {
            get { return mstrArea; }
            set { mstrArea = value; }
        }
        String mstrTransactionSpecification = null;
        public String TransactionSpecification
        {
            get { return mstrTransactionSpecification; }
            set { mstrTransactionSpecification = value; }
        }
        String mstrNoSeries = null;
        public String NoSeries
        {
            get { return mstrNoSeries; }
            set { mstrNoSeries = value; }
        }
        Int32? mnumDocumentType = null;
        public Int32? DocumentType
        {
            get { return mnumDocumentType; }
            set { mnumDocumentType = value; }
        }
        Int32? mnumDocumentLineNo = null;
        public Int32? DocumentLineNo
        {
            get { return mnumDocumentLineNo; }
            set { mnumDocumentLineNo = value; }
        }
        String mstrJobNo = null;
        public String JobNo
        {
            get { return mstrJobNo; }
            set { mstrJobNo = value; }
        }
        String mstrJobTaskNo = null;
        public String JobTaskNo
        {
            get { return mstrJobTaskNo; }
            set { mstrJobTaskNo = value; }
        }
        String mstrJobPurchase = null;
        public String JobPurchase
        {
            get { return mstrJobPurchase; }
            set { mstrJobPurchase = value; }
        }
        String mstrProdOrderNo = null;
        public String ProdOrderNo
        {
            get { return mstrProdOrderNo; }
            set { mstrProdOrderNo = value; }
        }
        String mstrVariantCode = null;
        public String VariantCode
        {
            get { return mstrVariantCode; }
            set { mstrVariantCode = value; }
        }
        String mstrQtyPerUnitOfMeasure = null;
        public String QtyPerUnitOfMeasure
        {
            get { return mstrQtyPerUnitOfMeasure; }
            set { mstrQtyPerUnitOfMeasure = value; }
        }
        String mstrUnitOfMeasureCode = null;
        public String UnitOfMeasureCode
        {
            get { return mstrUnitOfMeasureCode; }
            set { mstrUnitOfMeasureCode = value; }
        }
        String mstrDerivedFromBlanketOrder = null;
        public String DerivedFromBlanketOrder
        {
            get { return mstrDerivedFromBlanketOrder; }
            set { mstrDerivedFromBlanketOrder = value; }
        }
        String mstrCrossReferenceNo = null;
        public String CrossReferenceNo
        {
            get { return mstrCrossReferenceNo; }
            set { mstrCrossReferenceNo = value; }
        }
        String mstrOriginallyOrderedNo = null;
        public String OriginallyOrderedNo
        {
            get { return mstrOriginallyOrderedNo; }
            set { mstrOriginallyOrderedNo = value; }
        }
        String mstrOriginallyOrderedVarCode = null;
        public String OriginallyOrderedVarCode
        {
            get { return mstrOriginallyOrderedVarCode; }
            set { mstrOriginallyOrderedVarCode = value; }
        }
        String mstrOutOfStockSubstitution = null;
        public String OutOfStockSubstitution
        {
            get { return mstrOutOfStockSubstitution; }
            set { mstrOutOfStockSubstitution = value; }
        }
        String mstrOutofStockSubstitution = null;
        public String OutofStockSubstitution
        {
            get { return mstrOutofStockSubstitution; }
            set { mstrOutofStockSubstitution = value; }
        }
        String mstrItemCategoryCode = null;
        public String ItemCategoryCode
        {
            get { return mstrItemCategoryCode; }
            set { mstrItemCategoryCode = value; }
        }
        String mstrNonstock = null;
        public String Nonstock
        {
            get { return mstrNonstock; }
            set { mstrNonstock = value; }
        }
        String mstrPurchasingCode = null;
        public String PurchasingCode
        {
            get { return mstrPurchasingCode; }
            set { mstrPurchasingCode = value; }
        }


        String mstrProductGroupCode = null;
        public String ProductGroupCode
        {
            get { return mstrProductGroupCode; }
            set { mstrProductGroupCode = value; }
        }

        String mstrTransferOrderNo = null;
        public String TransferOrderNo
        {
            get { return mstrTransferOrderNo; }
            set { mstrTransferOrderNo = value; }
        }

        String mstrCompletelyInvoiced = null;
        public String CompletelyInvoiced
        {
            get { return mstrCompletelyInvoiced; }
            set { mstrCompletelyInvoiced = value; }
        }
        String mstrLastInvoiceDate = null;
        public String LastInvoiceDate
        {
            get { return mstrLastInvoiceDate; }
            set { mstrLastInvoiceDate = value; }
        }
        String mstrAppliedEntrytoAdjust = null;
        public String AppliedEntrytoAdjust
        {
            get { return mstrAppliedEntrytoAdjust; }
            set { mstrAppliedEntrytoAdjust = value; }
        }

        String mstrCorrection = null;
        public String Correction
        {
            get { return mstrCorrection; }
            set { mstrCorrection = value; }
        }
        String mstrShippedQtyNotReturned = null;
        public String ShippedQtyNotReturned
        {
            get { return mstrShippedQtyNotReturned; }
            set { mstrShippedQtyNotReturned = value; }
        }
        Int32? mnumProdOrderLineNo = null;
        public Int32? ProdOrderLineNo
        {
            get { return mnumProdOrderLineNo; }
            set { mnumProdOrderLineNo = value; }
        }
        Int32? mnumProdOrderCompLineNo = null;
        public Int32? ProdOrderCompLineNo
        {
            get { return mnumProdOrderCompLineNo; }
            set { mnumProdOrderCompLineNo = value; }
        }

        String mstrServiceOrderNo = null;
        public String ServiceOrderNo
        {
            get { return mstrServiceOrderNo; }
            set { mstrServiceOrderNo = value; }
        }

        String mstrSerialNo = null;
        public String SerialNo
        {
            get { return mstrSerialNo; }
            set { mstrSerialNo = value; }
        }

        String mstrLotNo = null;
        public String LotNo
        {
            get { return mstrLotNo; }
            set { mstrLotNo = value; }
        }

        String mstrWarrantyDate = null;
        public String WarrantyDate
        {
            get { return mstrWarrantyDate; }
            set { mstrWarrantyDate = value; }
        }

        String mstrExpirationDate = null;
        public String ExpirationDate
        {
            get { return mstrExpirationDate; }
            set { mstrExpirationDate = value; }
        }

        Int32?  mnumItemTracking = null;
        public Int32? ItemTracking
        {
            get { return mnumItemTracking; }
            set { mnumItemTracking = value; }
        }

        String mstrReturnReasonCode = null;
        public String ReturnReasonCode
        {
            get { return mstrReturnReasonCode; }
            set { mstrReturnReasonCode = value; }
        }


        String mstrActiveSerial = null;
        public String ActiveSerial
        {
            get { return mstrActiveSerial; }
            set { mstrActiveSerial = value; }
        }

        String mstrGlobalDimension3Code = null;
        public String GlobalDimension3Code
        {
            get { return mstrGlobalDimension3Code; }
            set { mstrGlobalDimension3Code = value; }
        }

        String mstrGlobalDimension4Code = null;
        public String GlobalDimension4Code
        {
            get { return mstrGlobalDimension4Code; }
            set { mstrGlobalDimension4Code = value; }
        }

        String mstrGlobalDimension5Code = null;
        public String GlobalDimension5Code
        {
            get { return mstrGlobalDimension5Code; }
            set { mstrGlobalDimension5Code = value; }
        }

        String mstrGlobalDimension6Code = null;
        public String GlobalDimension6Code
        {
            get { return mstrGlobalDimension6Code; }
            set { mstrGlobalDimension6Code = value; }
        }

        String mstrGlobalDimension7Code = null;
        public String GlobalDimension7Code
        {
            get { return mstrGlobalDimension7Code; }
            set { mstrGlobalDimension7Code = value; }
        }

        String mstrRegisterCar = null;
        public String RegisterCar
        {
            get { return mstrRegisterCar; }
            set { mstrRegisterCar = value; }
        }

        String mstrArrivalDate = null;
        public String ArrivalDate
        {
            get { return mstrArrivalDate; }
            set { mstrArrivalDate = value; }
        }

        String mstrCustomerNo = null;
        public String CustomerNo
        {
            get { return mstrCustomerNo; }
            set { mstrCustomerNo = value; }
        }

        String mstrCustomerLoteNumber = null;
        public String CustomerLoteNumber
        {
            get { return mstrCustomerLoteNumber; }
            set { mstrCustomerLoteNumber = value; }
        }

        String mstrTerminal = null;
        public String Terminal
        {
            get { return mstrTerminal; }
            set { mstrTerminal = value; }
        }

        String mstrHandlingOpType = null;
        public String HandlingOpType
        {
            get { return mstrHandlingOpType; }
            set { mstrHandlingOpType = value; }
        }

        Int32? mstrOperativeSource = null;
        public Int32? OperativeSource
        {
            get { return mstrOperativeSource; }
            set { mstrOperativeSource = value; }
        }

        String mstrCustomerItemNo = null;
        public String CustomerItemNo
        {
            get { return mstrCustomerItemNo; }
            set { mstrCustomerItemNo = value; }
        }

        String mstrMovementDescription = null;
        public String MovementDescription
        {
            get { return mstrMovementDescription; }
            set { mstrMovementDescription = value; }
        }

        String mstrPemexOrderLineNo = null;
        public String PemexOrderLineNo
        {
            get { return mstrPemexOrderLineNo; }
            set { mstrPemexOrderLineNo = value; }
        }

        String mstrDocumentMWONo = null;
        public String DocumentMWONo
        {
            get { return mstrDocumentMWONo; }
            set { mstrDocumentMWONo = value; }
        }

        String mstrMachineNo = null;
        public String MachineNo
        {
            get { return mstrMachineNo; }
            set { mstrMachineNo = value; }
        }

        String mstrGenBusPostingGroup = null;
        public String GenBusPostingGroup
        {
            get { return mstrGenBusPostingGroup; }
            set { mstrGenBusPostingGroup = value; }
        }

        String mstrPackingCode = null;
        public String PackingCode
        {
            get { return mstrPackingCode; }
            set { mstrPackingCode = value; }
        }

        String mstrQtyWeightperPacking = null;
        public String QtyWeightperPacking
        {
            get { return mstrQtyWeightperPacking; }
            set { mstrQtyWeightperPacking = value; }
        }

        String mstrQtyPackingsperPallet = null;
        public String QtyPackingsperPallet
        {
            get { return mstrQtyPackingsperPallet; }
            set { mstrQtyPackingsperPallet = value; }
        }

        String mstrPallet = null;
        public String Pallet
        {
            get { return mstrPallet; }
            set { mstrPallet = value; }
        }

        String mstrPalletNoConform = null;
        public String PalletNoConform
        {
            get { return mstrPalletNoConform; }
            set { mstrPalletNoConform = value; }
        }

        String mstrLegend = null;
        public String Legend
        {
            get { return mstrLegend; }
            set { mstrLegend = value; }
        }

        String mstrNoTalon = null;
        public String NoTalon
        {
            get { return mstrNoTalon; }
            set { mstrNoTalon = value; }
        }

        String mstrIngenio = null;
        public String Ingenio
        {
            get { return mstrIngenio; }
            set { mstrIngenio = value; }
        }

        String mstrZafra = null;
        public String Zafra
        {
            get { return mstrZafra; }
            set { mstrZafra = value; }
        }

        String mstrSugar = null;
        public String Sugar
        {
            get { return mstrSugar; }
            set { mstrSugar = value; }
        }

        String mstrBinCode = null;
        public String BinCode
        {
            get { return mstrBinCode; }
            set { mstrBinCode = value; }
        }

        String mstrMotiveNonConformity = null;
        public String MotiveNonConformity
        {
            get { return mstrMotiveNonConformity; }
            set { mstrMotiveNonConformity = value; }
        }

        String mstrRecoveryActions = null;
        public String RecoveryActions
        {
            get { return mstrRecoveryActions; }
            set { mstrRecoveryActions = value; }
        }

        Int32? mnumSourceConsumption = null;
        public Int32? SourceConsumption
        {
            get { return mnumSourceConsumption; }
            set { mnumSourceConsumption = value; }
        }

        Int32? mnumTypeConsumption = null;
        public Int32? TypeConsumption
        {
            get { return mnumTypeConsumption; }
            set { mnumTypeConsumption = value; }
        }

        Int32? mnumTypeConsumptionProduction = null;
        public Int32? TypeConsumptionProduction
        {
            get { return mnumTypeConsumptionProduction; }
            set { mnumTypeConsumptionProduction = value; }
        }

        String mstrDestinationlocationcode = null;
        public String Destinationlocationcode
        {
            get { return mstrDestinationlocationcode; }
            set { mstrDestinationlocationcode = value; }
        }

        String mstrUser = null;
        public String User
        {
            get { return mstrUser; }
            set { mstrUser = value; }
        }

        String mstrWorksheetdemand = null;
        public String Worksheetdemand
        {
            get { return mstrWorksheetdemand; }
            set { mstrWorksheetdemand = value; }
        }

        String mstrInCustomerCharge = null;
        public String InCustomerCharge
        {
            get { return mstrInCustomerCharge; }
            set { mstrInCustomerCharge = value; }
        }

        String mstrUserNoConform = null;
        public String UserNoConform
        {
            get { return mstrUserNoConform; }
            set { mstrUserNoConform = value; }
        }

        String mstrDateNoConform = null;
        public String DateNoConform
        {
            get { return mstrDateNoConform; }
            set { mstrDateNoConform = value; }
        }

        String mstrTimeNoConform = null;
        public String TimeNoConform
        {
            get { return mstrTimeNoConform; }
            set { mstrTimeNoConform = value; }
        }

        String mstrSplitPallet = null;
        public String SplitPallet
        {
            get { return mstrSplitPallet; }
            set { mstrSplitPallet = value; }
        }

        String mstrUserSpliter = null;
        public String UserSpliter
        {
            get { return mstrUserSpliter; }
            set { mstrUserSpliter = value; }
        }

        String mstrDateSpliter = null;
        public String DateSpliter
        {
            get { return mstrDateSpliter; }
            set { mstrDateSpliter = value; }
        }

        String mstrTimeSpliter = null;
        public String TimeSpliter
        {
            get { return mstrTimeSpliter; }
            set { mstrTimeSpliter = value; }
        }

        String mstrPalletSourceNo = null;
        public String PalletSourceNo
        {
            get { return mstrPalletSourceNo; }
            set { mstrPalletSourceNo = value; }
        }

        String mstrStorageDate = null;
        public String StorageDate
        {
            get { return mstrStorageDate; }
            set { mstrStorageDate = value; }
        }

        String mstrReferenceMov = null;
        public String ReferenceMov
        {
            get { return mstrReferenceMov; }
            set { mstrReferenceMov = value; }
        }

        String mstrActivityPoS = null;
        public String ActivityPoS
        {
            get { return mstrActivityPoS; }
            set { mstrActivityPoS = value; }
        }

        String mstrItemReturn = null;
        public String ItemReturn
        {
            get { return mstrItemReturn; }
            set { mstrItemReturn = value; }
        }

        Int32? mnumFinalidad = null;
        public Int32? Finalidad
        {
            get { return mnumFinalidad; }
            set { mnumFinalidad = value; }
        }

        String mstrLiberadoporCalidad = null;
        public String LiberadoporCalidad
        {
            get { return mstrLiberadoporCalidad; }
            set { mstrLiberadoporCalidad = value; }
        }

        String mstrCambiodeUbicacion = null;
        public String CambiodeUbicacion
        {
            get { return mstrCambiodeUbicacion; }
            set { mstrCambiodeUbicacion = value; }
        }

        String mstrUltimaUbicacion = null;
        public String UltimaUbicacion
        {
            get { return mstrUltimaUbicacion; }
            set { mstrUltimaUbicacion = value; }
        }

        String mstrSoloCambiodeUbicacion = null;
        public String SoloCambiodeUbicacion
        {
            get { return mstrSoloCambiodeUbicacion; }
            set { mstrSoloCambiodeUbicacion = value; }
        }

        String mstrSCambiodeUbi = null;
        public String SCambiodeUbi
        {
            get { return mstrSCambiodeUbi; }
            set { mstrSCambiodeUbi = value; }
        }

        String mstrUltima_Ubicacion = null;
        public String Ultima_Ubicacion
        {
            get { return mstrUltima_Ubicacion; }
            set { mstrUltima_Ubicacion = value; }
        }


        #endregion
    }
}
