using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerConfigurator.Storage.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Audiocards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Interface = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sound = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PictureUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastAccessTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "sysdate(3)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audiocards", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Coolers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FanCount = table.Column<int>(type: "int", nullable: false),
                    FanSize = table.Column<int>(type: "int", nullable: false),
                    BlowDirection = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BlowPowerCfm = table.Column<double>(type: "double", nullable: false),
                    NoiseLevel = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FanSpeed = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BearingType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TdpMax = table.Column<int>(type: "int", nullable: false),
                    Base = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsePipes = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Connector = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PowerMax = table.Column<double>(type: "double", nullable: false),
                    Lighting = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Lenght = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PictureUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastAccessTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "sysdate(3)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coolers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FormFactors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormFactors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GraphicCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Interface = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChipsetBrand = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChipsetModel = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Frequency = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TechProc = table.Column<int>(type: "int", nullable: false),
                    MemoryAmount = table.Column<int>(type: "int", nullable: false),
                    MemoryType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MemoryFreq = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MemoryBusBit = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ResolutionMax = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DirectXOpenGlVer = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RayTracing = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NvidiaSupport = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DlssSupport = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DviCount = table.Column<int>(type: "int", nullable: false),
                    HdmiCount = table.Column<int>(type: "int", nullable: false),
                    DisplayPortCount = table.Column<int>(type: "int", nullable: false),
                    HdmiVer = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayPortVer = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MonitorCount = table.Column<int>(type: "int", nullable: false),
                    ConnectorType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PowerMax = table.Column<int>(type: "int", nullable: false),
                    PowerReccomended = table.Column<int>(type: "int", nullable: false),
                    Lenght = table.Column<int>(type: "int", nullable: false),
                    Thickness = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PictureUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastAccessTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "sysdate(3)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraphicCards", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HardDisks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeHdd = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FormFactor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    BufferCapacity = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpeedSpin = table.Column<int>(type: "int", nullable: false),
                    IntefaceType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IntefaceMaxSpeed = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Latency = table.Column<int>(type: "int", nullable: false),
                    TimeToFail = table.Column<int>(type: "int", nullable: false),
                    PowerMax = table.Column<double>(type: "double", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PictureUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastAccessTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "sysdate(3)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardDisks", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Psu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FormFactor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AtxVersion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Power = table.Column<int>(type: "int", nullable: false),
                    IsModular = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Certificate = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pfc = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Color = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MotherboardConnector = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GraphicCardConnector = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SataCount = table.Column<int>(type: "int", nullable: false),
                    MolexCount = table.Column<int>(type: "int", nullable: false),
                    FddCount = table.Column<int>(type: "int", nullable: false),
                    FanSize = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FanCount = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ThermalRegulator = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Size = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PictureUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastAccessTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "sysdate(3)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psu", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ram",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FormFactor = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    PinCount = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModulCount = table.Column<int>(type: "int", nullable: false),
                    ChannelsCount = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Speed = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsEcc = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    Voltage = table.Column<double>(type: "double", nullable: false),
                    Delay = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Latency = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FrequencyDefault = table.Column<int>(type: "int", nullable: false),
                    DelayDefault = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VoltageDefault = table.Column<double>(type: "double", nullable: false),
                    CountChip = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PictureUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastAccessTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "sysdate(3)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ram", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sockets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sockets", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SsdDisks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeDisk = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    FormFactor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inteface = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NandType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nvme = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SpeedReadMax = table.Column<int>(type: "int", nullable: false),
                    SpeedWriteMax = table.Column<int>(type: "int", nullable: false),
                    Tbw = table.Column<int>(type: "int", nullable: false),
                    TimeToFail = table.Column<int>(type: "int", nullable: false),
                    PowerMax = table.Column<double>(type: "double", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PictureUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastAccessTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "sysdate(3)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SsdDisks", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Casings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdFormFactor = table.Column<int>(type: "int", nullable: false),
                    CountSection25 = table.Column<int>(name: "CountSection2_5", type: "int", nullable: false),
                    CountSection35 = table.Column<int>(name: "CountSection3_5", type: "int", nullable: false),
                    SpecificationSection = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CountSlotsExtension = table.Column<int>(type: "int", nullable: false),
                    LocationHdd = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GraphicCardMaxLenght = table.Column<int>(type: "int", nullable: false),
                    CoolerHeightMax = table.Column<int>(type: "int", nullable: false),
                    PsuLenghtMax = table.Column<int>(type: "int", nullable: false),
                    CountUSB3 = table.Column<int>(type: "int", nullable: false),
                    CountUSB31TypeC = table.Column<int>(type: "int", nullable: false),
                    CountUSB2 = table.Column<int>(type: "int", nullable: false),
                    AudioJack = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FrontFans = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BackFans = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddFans = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PsuLocation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PsuPower = table.Column<int>(type: "int", nullable: false),
                    PsuCertificate = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SidePanel = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SidePanelMaterial = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CanWater = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Color = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PictureUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastAccessTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "sysdate(3)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Casings_FormFactors_IdFormFactor",
                        column: x => x.IdFormFactor,
                        principalTable: "FormFactors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Motherboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdSocket = table.Column<int>(type: "int", nullable: false),
                    ChipsetBrand = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChipsetModel = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RamType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RamFrequencyMax = table.Column<int>(type: "int", nullable: false),
                    RamFrequency = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RamCountDDR5 = table.Column<int>(type: "int", nullable: false),
                    RamCountDDR4 = table.Column<int>(type: "int", nullable: false),
                    RamCountDDR3 = table.Column<int>(type: "int", nullable: false),
                    RamCountDDR2 = table.Column<int>(type: "int", nullable: false),
                    RamAmountMax = table.Column<int>(type: "int", nullable: false),
                    RamMode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PCIe1Count = table.Column<int>(type: "int", nullable: false),
                    PCIe2Count = table.Column<int>(type: "int", nullable: false),
                    PCIe3Count = table.Column<int>(type: "int", nullable: false),
                    PCIe4Count = table.Column<int>(type: "int", nullable: false),
                    PCIe5Count = table.Column<int>(type: "int", nullable: false),
                    PCIeX16Speed = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sata3Count = table.Column<int>(type: "int", nullable: false),
                    Sata2Count = table.Column<int>(type: "int", nullable: false),
                    M2Count = table.Column<int>(type: "int", nullable: false),
                    IntelOptane = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SataRaid = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Usb30Count = table.Column<int>(type: "int", nullable: false),
                    Usb31Count = table.Column<int>(type: "int", nullable: false),
                    Usb20Count = table.Column<int>(type: "int", nullable: false),
                    VgaCount = table.Column<int>(type: "int", nullable: false),
                    DisplayPortCount = table.Column<int>(type: "int", nullable: false),
                    HdmiCount = table.Column<int>(type: "int", nullable: false),
                    ThunderboltCount = table.Column<int>(type: "int", nullable: false),
                    NetworkInterface = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Wifi = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Bluetooth = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AudioType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AudioController = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdFormFactor = table.Column<int>(type: "int", nullable: false),
                    PowerConnector = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PictureUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastAccessTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "sysdate(3)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motherboards_FormFactors_IdFormFactor",
                        column: x => x.IdFormFactor,
                        principalTable: "FormFactors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motherboards_Sockets_IdSocket",
                        column: x => x.IdSocket,
                        principalTable: "Sockets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Processors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CoreName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdSocket = table.Column<int>(type: "int", nullable: false),
                    CountOfCores = table.Column<int>(type: "int", nullable: false),
                    CountOfThreads = table.Column<int>(type: "int", nullable: false),
                    Frequency = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    L3cache = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bit = table.Column<int>(type: "int", nullable: false),
                    TechProc = table.Column<int>(type: "int", nullable: false),
                    Multiplier = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    BusCapacity = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Heat = table.Column<int>(type: "int", nullable: false),
                    MaxTemperature = table.Column<int>(type: "int", nullable: false),
                    Package = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RamMax = table.Column<int>(type: "int", nullable: false),
                    RamType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RamFreq = table.Column<int>(type: "int", nullable: false),
                    RamCountOfChannels = table.Column<int>(type: "int", nullable: false),
                    RamBusCapacity = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RamEccReg = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PciVer = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PciCountOfChannels = table.Column<int>(type: "int", nullable: false),
                    PciConfiguration = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GpuExist = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    GpuModel = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GpuFreq = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GpuMemory = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PictureUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastAccessTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "sysdate(3)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Processors_Sockets_IdSocket",
                        column: x => x.IdSocket,
                        principalTable: "Sockets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SocketCooler",
                columns: table => new
                {
                    IdCooler = table.Column<int>(type: "int", nullable: false),
                    IdSocket = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocketCooler", x => new { x.IdSocket, x.IdCooler });
                    table.ForeignKey(
                        name: "FK_SocketCooler_Coolers_IdCooler",
                        column: x => x.IdCooler,
                        principalTable: "Coolers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocketCooler_Sockets_IdSocket",
                        column: x => x.IdSocket,
                        principalTable: "Sockets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProcessorId = table.Column<int>(type: "int", nullable: true),
                    GraphicCardId = table.Column<int>(type: "int", nullable: true),
                    MotherboardId = table.Column<int>(type: "int", nullable: true),
                    HddId = table.Column<int>(type: "int", nullable: true),
                    SsdId = table.Column<int>(type: "int", nullable: true),
                    CasingId = table.Column<int>(type: "int", nullable: true),
                    CoolerId = table.Column<int>(type: "int", nullable: true),
                    PsuId = table.Column<int>(type: "int", nullable: true),
                    RamId = table.Column<int>(type: "int", nullable: true),
                    RamCount = table.Column<int>(type: "int", nullable: false),
                    AudiocardId = table.Column<int>(type: "int", nullable: true),
                    LastAccessTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "sysdate(3)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configurations_Audiocards_AudiocardId",
                        column: x => x.AudiocardId,
                        principalTable: "Audiocards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configurations_Casings_CasingId",
                        column: x => x.CasingId,
                        principalTable: "Casings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configurations_Coolers_CoolerId",
                        column: x => x.CoolerId,
                        principalTable: "Coolers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configurations_GraphicCards_GraphicCardId",
                        column: x => x.GraphicCardId,
                        principalTable: "GraphicCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Configurations_HardDisks_HddId",
                        column: x => x.HddId,
                        principalTable: "HardDisks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configurations_Motherboards_MotherboardId",
                        column: x => x.MotherboardId,
                        principalTable: "Motherboards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configurations_Processors_ProcessorId",
                        column: x => x.ProcessorId,
                        principalTable: "Processors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configurations_Psu_PsuId",
                        column: x => x.PsuId,
                        principalTable: "Psu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configurations_Ram_RamId",
                        column: x => x.RamId,
                        principalTable: "Ram",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configurations_SsdDisks_SsdId",
                        column: x => x.SsdId,
                        principalTable: "SsdDisks",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Casings_IdFormFactor",
                table: "Casings",
                column: "IdFormFactor");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_AudiocardId",
                table: "Configurations",
                column: "AudiocardId");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_CasingId",
                table: "Configurations",
                column: "CasingId");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_CoolerId",
                table: "Configurations",
                column: "CoolerId");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_GraphicCardId",
                table: "Configurations",
                column: "GraphicCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_HddId",
                table: "Configurations",
                column: "HddId");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_MotherboardId",
                table: "Configurations",
                column: "MotherboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_ProcessorId",
                table: "Configurations",
                column: "ProcessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_PsuId",
                table: "Configurations",
                column: "PsuId");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_RamId",
                table: "Configurations",
                column: "RamId");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_SsdId",
                table: "Configurations",
                column: "SsdId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_IdFormFactor",
                table: "Motherboards",
                column: "IdFormFactor");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_IdSocket",
                table: "Motherboards",
                column: "IdSocket");

            migrationBuilder.CreateIndex(
                name: "IX_Processors_IdSocket",
                table: "Processors",
                column: "IdSocket");

            migrationBuilder.CreateIndex(
                name: "IX_SocketCooler_IdCooler",
                table: "SocketCooler",
                column: "IdCooler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "SocketCooler");

            migrationBuilder.DropTable(
                name: "Audiocards");

            migrationBuilder.DropTable(
                name: "Casings");

            migrationBuilder.DropTable(
                name: "GraphicCards");

            migrationBuilder.DropTable(
                name: "HardDisks");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "Processors");

            migrationBuilder.DropTable(
                name: "Psu");

            migrationBuilder.DropTable(
                name: "Ram");

            migrationBuilder.DropTable(
                name: "SsdDisks");

            migrationBuilder.DropTable(
                name: "Coolers");

            migrationBuilder.DropTable(
                name: "FormFactors");

            migrationBuilder.DropTable(
                name: "Sockets");
        }
    }
}
