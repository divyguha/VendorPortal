using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VendorApi.Migrations
{
    public partial class migration_9Aug22_year_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Circulars",
                columns: table => new
                {
                    CircularId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CircularDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CircularSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CircularMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnteredBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circulars", x => x.CircularId);
                });

            migrationBuilder.CreateTable(
                name: "TaxPercentages",
                columns: table => new
                {
                    TaxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConditionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConditionTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxRate = table.Column<decimal>(type: "decimal(5,3)", nullable: false),
                    SAPPONo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxPercentages", x => x.TaxId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    Disabled = table.Column<int>(type: "int", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegisterLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SAPVendorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SAPVendorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvidePortalAccess = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    Disablestatus = table.Column<bool>(type: "bit", nullable: true),
                    StatementofAccount = table.Column<bool>(type: "bit", nullable: true),
                    showPrices = table.Column<bool>(type: "bit", nullable: true),
                    EnteredBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POBox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CircularDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorId);
                });

            migrationBuilder.CreateTable(
                name: "CircularDetails",
                columns: table => new
                {
                    CircularDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    CricularId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Viewed = table.Column<int>(type: "int", nullable: false),
                    CircularId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CircularDetails", x => x.CircularDetailId);
                    table.ForeignKey(
                        name: "FK_CircularDetails_Circulars_CircularId",
                        column: x => x.CircularId,
                        principalTable: "Circulars",
                        principalColumn: "CircularId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CircularDetails_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "POMains",
                columns: table => new
                {
                    POMainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SAPPONo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PODate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TINNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ECCNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PANNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SRVTaxNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POValue = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TermsConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedStatus = table.Column<bool>(type: "bit", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SAPVendorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnapprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnApprovedStatus = table.Column<bool>(type: "bit", nullable: false),
                    UnapprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReleaseStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POHeaderText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VendorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POMains", x => x.POMainId);
                    table.ForeignKey(
                        name: "FK_POMains_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryScheduleMains",
                columns: table => new
                {
                    DeliveryScheduleMainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POMainId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    DSMonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSYear = table.Column<int>(type: "int", nullable: false),
                    DSWorkingdays = table.Column<int>(type: "int", nullable: false),
                    DSEnteredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    venSupplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    venDSMonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    venDSYear = table.Column<int>(type: "int", nullable: false),
                    venDSWorkingDays = table.Column<int>(type: "int", nullable: false),
                    venModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    venModifiedBy = table.Column<int>(type: "int", nullable: false),
                    DApprovedBy = table.Column<int>(type: "int", nullable: false),
                    DApprovedStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryScheduleType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryScheduleMains", x => x.DeliveryScheduleMainId);
                    table.ForeignKey(
                        name: "FK_DeliveryScheduleMains_POMains_POMainId",
                        column: x => x.POMainId,
                        principalTable: "POMains",
                        principalColumn: "POMainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceMains",
                columns: table => new
                {
                    InvoiceMainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POMainId = table.Column<int>(type: "int", nullable: false),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cenvat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EDCess = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SHECess = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModeOfTransport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransporterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfConsignee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    TotalInvoiceAmount = table.Column<int>(type: "int", nullable: false),
                    GRNNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GRNDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarcodeGenerated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalGrossAmount = table.Column<int>(type: "int", nullable: false),
                    Form16 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TripNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackagingTotalAmount = table.Column<int>(type: "int", nullable: false),
                    FreightTotalAmount = table.Column<int>(type: "int", nullable: false),
                    OthersTotalAmount = table.Column<int>(type: "int", nullable: false),
                    Servicetax = table.Column<int>(type: "int", nullable: false),
                    IssueYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormAmount = table.Column<int>(type: "int", nullable: false),
                    FormNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnteredDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalCgst = table.Column<int>(type: "int", nullable: false),
                    TotalSgst = table.Column<int>(type: "int", nullable: false),
                    TotalIgst = table.Column<int>(type: "int", nullable: false),
                    GstImpl = table.Column<int>(type: "int", nullable: false),
                    EwayNum = table.Column<int>(type: "int", nullable: false),
                    BarcodeText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceMains", x => x.InvoiceMainId);
                    table.ForeignKey(
                        name: "FK_InvoiceMains_POMains_POMainId",
                        column: x => x.POMainId,
                        principalTable: "POMains",
                        principalColumn: "POMainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PODetails",
                columns: table => new
                {
                    PODetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POMainId = table.Column<int>(type: "int", nullable: false),
                    MaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePerUnit = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    GrossValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SAPCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PONumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetValue = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    LockStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PODetails", x => x.PODetailId);
                    table.ForeignKey(
                        name: "FK_PODetails_POMains_POMainId",
                        column: x => x.POMainId,
                        principalTable: "POMains",
                        principalColumn: "POMainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryScheduleDetails",
                columns: table => new
                {
                    DeliveryScheduleDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryScheduleMainId = table.Column<int>(type: "int", nullable: false),
                    MaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SAPCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Week1 = table.Column<int>(type: "int", nullable: false),
                    Week2 = table.Column<int>(type: "int", nullable: false),
                    Week3 = table.Column<int>(type: "int", nullable: false),
                    Week4 = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    TentativeMonth1 = table.Column<int>(type: "int", nullable: false),
                    TentativeMonth2 = table.Column<int>(type: "int", nullable: false),
                    venMaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    venSAPCode = table.Column<int>(type: "int", nullable: false),
                    vendorWeek1 = table.Column<int>(type: "int", nullable: false),
                    vendorWeek2 = table.Column<int>(type: "int", nullable: false),
                    vendorWeek3 = table.Column<int>(type: "int", nullable: false),
                    vendortotal = table.Column<int>(type: "int", nullable: false),
                    venTentativeMonth1 = table.Column<int>(type: "int", nullable: false),
                    venTentativeMonth2 = table.Column<int>(type: "int", nullable: false),
                    DailyDeliveryQty = table.Column<int>(type: "int", nullable: false),
                    DailyReceivedQty = table.Column<int>(type: "int", nullable: false),
                    Gap = table.Column<int>(type: "int", nullable: false),
                    CarryForward = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryScheduleType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryScheduleDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryScheduleDetails", x => x.DeliveryScheduleDetailId);
                    table.ForeignKey(
                        name: "FK_DeliveryScheduleDetails_DeliveryScheduleMains_DeliveryScheduleMainId",
                        column: x => x.DeliveryScheduleMainId,
                        principalTable: "DeliveryScheduleMains",
                        principalColumn: "DeliveryScheduleMainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GRNMains",
                columns: table => new
                {
                    GRNMainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POMainId = table.Column<int>(type: "int", nullable: false),
                    GRNNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GRNDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    J1IANo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExciseDocNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillOfLading = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocHeaderText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InspectionLot = table.Column<int>(type: "int", nullable: false),
                    TruckNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceMainId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PONum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnteredDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceMainId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRNMains", x => x.GRNMainId);
                    table.ForeignKey(
                        name: "FK_GRNMains_InvoiceMains_InvoiceMainId1",
                        column: x => x.InvoiceMainId1,
                        principalTable: "InvoiceMains",
                        principalColumn: "InvoiceMainId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GRNMains_POMains_POMainId",
                        column: x => x.POMainId,
                        principalTable: "POMains",
                        principalColumn: "POMainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    InvoiceDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceMainId = table.Column<int>(type: "int", nullable: false),
                    NoOfPKTS = table.Column<int>(type: "int", nullable: false),
                    MaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalQuantityDespatched = table.Column<int>(type: "int", nullable: false),
                    PricePerUnit = table.Column<int>(type: "int", nullable: false),
                    InvoiceAmount = table.Column<int>(type: "int", nullable: false),
                    EntereDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnteredBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalInvoiceAmount = table.Column<int>(type: "int", nullable: false),
                    MCenvat = table.Column<int>(type: "int", nullable: false),
                    MEDCess = table.Column<int>(type: "int", nullable: false),
                    MSHECess = table.Column<int>(type: "int", nullable: false),
                    MSTax = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Packaging = table.Column<int>(type: "int", nullable: false),
                    Freight = table.Column<int>(type: "int", nullable: false),
                    Others = table.Column<int>(type: "int", nullable: false),
                    MServiceTax = table.Column<int>(type: "int", nullable: false),
                    MCgst = table.Column<int>(type: "int", nullable: false),
                    MSgst = table.Column<int>(type: "int", nullable: false),
                    MIgst = table.Column<int>(type: "int", nullable: false),
                    MCgstPercent = table.Column<int>(type: "int", nullable: false),
                    MSgstPercent = table.Column<int>(type: "int", nullable: false),
                    MIgstPercent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.InvoiceDetailId);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_InvoiceMains_InvoiceMainId",
                        column: x => x.InvoiceMainId,
                        principalTable: "InvoiceMains",
                        principalColumn: "InvoiceMainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GRNDetails",
                columns: table => new
                {
                    GRNDetailsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GRNMainId = table.Column<int>(type: "int", nullable: false),
                    InvoiceMainId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    POMainId = table.Column<int>(type: "int", nullable: false),
                    GRNQty = table.Column<int>(type: "int", nullable: false),
                    RecievedQty = table.Column<int>(type: "int", nullable: false),
                    AcceptQty = table.Column<int>(type: "int", nullable: false),
                    RejectQty = table.Column<int>(type: "int", nullable: false),
                    MaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RejectReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GRNNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SAPPONo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRNDetails", x => x.GRNDetailsID);
                    table.ForeignKey(
                        name: "FK_GRNDetails_GRNMains_GRNMainId",
                        column: x => x.GRNMainId,
                        principalTable: "GRNMains",
                        principalColumn: "GRNMainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CircularDetails_CircularId",
                table: "CircularDetails",
                column: "CircularId");

            migrationBuilder.CreateIndex(
                name: "IX_CircularDetails_VendorId",
                table: "CircularDetails",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryScheduleDetails_DeliveryScheduleMainId",
                table: "DeliveryScheduleDetails",
                column: "DeliveryScheduleMainId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryScheduleMains_POMainId",
                table: "DeliveryScheduleMains",
                column: "POMainId");

            migrationBuilder.CreateIndex(
                name: "IX_GRNDetails_GRNMainId",
                table: "GRNDetails",
                column: "GRNMainId");

            migrationBuilder.CreateIndex(
                name: "IX_GRNMains_InvoiceMainId1",
                table: "GRNMains",
                column: "InvoiceMainId1");

            migrationBuilder.CreateIndex(
                name: "IX_GRNMains_POMainId",
                table: "GRNMains",
                column: "POMainId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceMainId",
                table: "InvoiceDetails",
                column: "InvoiceMainId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceMains_POMainId",
                table: "InvoiceMains",
                column: "POMainId");

            migrationBuilder.CreateIndex(
                name: "IX_PODetails_POMainId",
                table: "PODetails",
                column: "POMainId");

            migrationBuilder.CreateIndex(
                name: "IX_POMains_VendorId",
                table: "POMains",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CircularDetails");

            migrationBuilder.DropTable(
                name: "DeliveryScheduleDetails");

            migrationBuilder.DropTable(
                name: "GRNDetails");

            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "PODetails");

            migrationBuilder.DropTable(
                name: "TaxPercentages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Circulars");

            migrationBuilder.DropTable(
                name: "DeliveryScheduleMains");

            migrationBuilder.DropTable(
                name: "GRNMains");

            migrationBuilder.DropTable(
                name: "InvoiceMains");

            migrationBuilder.DropTable(
                name: "POMains");

            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
