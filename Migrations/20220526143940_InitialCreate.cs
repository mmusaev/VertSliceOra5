using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VertSliceOra5.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MARAT");

            migrationBuilder.CreateSequence(
                name: "SEQ_PERFORMANCE_CAPTURE",
                schema: "MARAT");

            migrationBuilder.CreateSequence(
                name: "TABLE1_SEQ",
                schema: "MARAT");

            migrationBuilder.CreateSequence(
                name: "TABLE2_SEQ",
                schema: "MARAT");

            migrationBuilder.CreateTable(
                name: "DEGREE_LEVELS",
                schema: "MARAT",
                columns: table => new
                {
                    DEGREE_LEVEL_CODE = table.Column<string>(type: "VARCHAR2(1)", unicode: false, maxLength: 1, nullable: false),
                    DEGREE_LEVEL_NAME = table.Column<string>(type: "VARCHAR2(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEGREE_LEVELS", x => x.DEGREE_LEVEL_CODE);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTMENTS",
                schema: "MARAT",
                columns: table => new
                {
                    DEPARTMENT_CODE = table.Column<string>(type: "VARCHAR2(2)", unicode: false, maxLength: 2, nullable: false),
                    DEPARTMENT_NAME = table.Column<string>(type: "VARCHAR2(25)", unicode: false, maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMENTS", x => x.DEPARTMENT_CODE);
                });

            migrationBuilder.CreateTable(
                name: "GRADES",
                schema: "MARAT",
                columns: table => new
                {
                    GRADE_CODE = table.Column<string>(type: "VARCHAR2(1)", unicode: false, maxLength: 1, nullable: false),
                    POINTS = table.Column<decimal>(type: "NUMBER(2,1)", nullable: true),
                    INCLUDE_IN_GPA = table.Column<bool>(type: "NUMBER(1)", precision: 1, nullable: false, defaultValueSql: "1 ")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRADES", x => x.GRADE_CODE);
                });

            migrationBuilder.CreateTable(
                name: "IM_RECONSIGNMENT",
                schema: "MARAT",
                columns: table => new
                {
                    PTR_RECONS = table.Column<long>(type: "NUMBER(12)", precision: 12, nullable: false),
                    PTR_PROD = table.Column<long>(type: "NUMBER(12)", precision: 12, nullable: true),
                    PTR_CO = table.Column<long>(type: "NUMBER(12)", precision: 12, nullable: true),
                    DTM_TRANS = table.Column<DateTime>(type: "DATE", nullable: true),
                    IDN_INV_OWNER = table.Column<string>(type: "VARCHAR2(10)", unicode: false, maxLength: 10, nullable: true),
                    DTM_BOOKED = table.Column<DateTime>(type: "DATE", nullable: true),
                    CDE_STATUS = table.Column<string>(type: "VARCHAR2(10)", unicode: false, maxLength: 10, nullable: true),
                    CDE_RECONS_TYPE = table.Column<string>(type: "VARCHAR2(10)", unicode: false, maxLength: 10, nullable: true),
                    PTR_FROM_LOC = table.Column<long>(type: "NUMBER(12)", precision: 12, nullable: true),
                    PTR_TO_LOC = table.Column<long>(type: "NUMBER(12)", precision: 12, nullable: true),
                    VOL_TRANS = table.Column<decimal>(type: "NUMBER(14,2)", nullable: true),
                    UOM_VOL = table.Column<string>(type: "VARCHAR2(3)", unicode: false, maxLength: 3, nullable: true),
                    CDE_RECONS_CONTRL_SELECT = table.Column<string>(type: "VARCHAR2(10)", unicode: false, maxLength: 10, nullable: true),
                    CDE_INV_SELECT = table.Column<string>(type: "VARCHAR2(10)", unicode: false, maxLength: 10, nullable: true),
                    CDE_RESERVE_SELECT = table.Column<string>(type: "VARCHAR2(10)", unicode: false, maxLength: 10, nullable: true),
                    DSC_STATUS_DTL = table.Column<string>(type: "VARCHAR2(2000)", unicode: false, maxLength: 2000, nullable: true),
                    DTM_UPD = table.Column<DateTime>(type: "DATE", nullable: true),
                    IDN_UPD_BY_USER = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: true),
                    FLG_DEL = table.Column<string>(type: "VARCHAR2(1)", unicode: false, maxLength: 1, nullable: true),
                    FLG_INTRNL = table.Column<string>(type: "VARCHAR2(1)", unicode: false, maxLength: 1, nullable: true),
                    DTE_BUS_BOOKED = table.Column<DateTime>(type: "DATE", nullable: true),
                    VAL_RVP = table.Column<decimal>(type: "NUMBER(3,1)", nullable: true),
                    DSC_COM = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IM_RECONSIGNMENT_PTR_RECONS", x => x.PTR_RECONS);
                });

            migrationBuilder.CreateTable(
                name: "MLOG$_TAB1",
                schema: "MARAT",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    NUM = table.Column<decimal>(type: "NUMBER", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "VARCHAR2(36)", unicode: false, maxLength: 36, nullable: true),
                    M_ROW = table.Column<string>(name: "M_ROW$$", type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: true),
                    SNAPTIME = table.Column<DateTime>(name: "SNAPTIME$$", type: "DATE", nullable: true),
                    DMLTYPE = table.Column<string>(name: "DMLTYPE$$", type: "VARCHAR2(1)", unicode: false, maxLength: 1, nullable: true),
                    OLD_NEW = table.Column<string>(name: "OLD_NEW$$", type: "VARCHAR2(1)", unicode: false, maxLength: 1, nullable: true),
                    CHANGE_VECTOR = table.Column<byte[]>(name: "CHANGE_VECTOR$$", type: "RAW(255)", maxLength: 255, nullable: true),
                    XID = table.Column<decimal>(name: "XID$$", type: "NUMBER", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PERF_STATS",
                schema: "MARAT",
                columns: table => new
                {
                    STAT_NAME = table.Column<string>(type: "VARCHAR2(40)", unicode: false, maxLength: 40, nullable: false),
                    DIVISOR = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false, defaultValueSql: "1 "),
                    UNITS = table.Column<string>(type: "VARCHAR2(20)", unicode: false, maxLength: 20, nullable: true),
                    DISPLAY_ORDER = table.Column<int>(type: "NUMBER(6)", precision: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C007520", x => x.STAT_NAME);
                });

            migrationBuilder.CreateTable(
                name: "PERFORMANCE_CAPTURE_STATS",
                schema: "MARAT",
                columns: table => new
                {
                    RUN_NUMBER = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "VARCHAR2(40)", unicode: false, maxLength: 40, nullable: false),
                    DATA_SEQUENCE = table.Column<short>(type: "NUMBER(5)", precision: 5, nullable: false),
                    STAT_NAME = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    STAT_VALUE = table.Column<decimal>(type: "NUMBER", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "RUPD$_TAB1",
                schema: "MARAT",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    DMLTYPE = table.Column<string>(name: "DMLTYPE$$", type: "VARCHAR2(1)", unicode: false, maxLength: 1, nullable: true),
                    SNAPID = table.Column<decimal>(type: "NUMBER(38)", nullable: true),
                    CHANGE_VECTOR = table.Column<byte[]>(name: "CHANGE_VECTOR$$", type: "RAW(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SESSIONS",
                schema: "MARAT",
                columns: table => new
                {
                    SESSION_CODE = table.Column<string>(type: "VARCHAR2(2)", unicode: false, maxLength: 2, nullable: false),
                    SESSION_NAME = table.Column<string>(type: "VARCHAR2(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PL_SESSIONS", x => x.SESSION_CODE);
                });

            migrationBuilder.CreateTable(
                name: "TAB1",
                schema: "MARAT",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "NUMBER", nullable: false),
                    NUM = table.Column<decimal>(type: "NUMBER", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "VARCHAR2(36)", unicode: false, maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAB1", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TEST",
                schema: "MARAT",
                columns: table => new
                {
                    COL1 = table.Column<decimal>(type: "NUMBER", nullable: true),
                    COL2 = table.Column<decimal>(type: "NUMBER", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TESTTB",
                schema: "MARAT",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    COLUMN2 = table.Column<string>(type: "VARCHAR2(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TESTTB", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CLASS_STANDINGS",
                schema: "MARAT",
                columns: table => new
                {
                    CLASS_STANDING_CODE = table.Column<string>(type: "VARCHAR2(2)", unicode: false, maxLength: 2, nullable: false),
                    CLASS_STANDING_NAME = table.Column<string>(type: "VARCHAR2(25)", unicode: false, maxLength: 25, nullable: false),
                    DEGREE_LEVEL_CODE = table.Column<string>(type: "VARCHAR2(1)", unicode: false, maxLength: 1, nullable: false),
                    REQUIRED_CREDITS = table.Column<byte>(type: "NUMBER(3)", precision: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLASS_STANDINGS", x => x.CLASS_STANDING_CODE);
                    table.ForeignKey(
                        name: "FK_CLASS_STDGS_DEGREE_LEVEL_CD",
                        column: x => x.DEGREE_LEVEL_CODE,
                        principalSchema: "MARAT",
                        principalTable: "DEGREE_LEVELS",
                        principalColumn: "DEGREE_LEVEL_CODE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DEGREE_TYPES",
                schema: "MARAT",
                columns: table => new
                {
                    DEGREE_TYPE_CODE = table.Column<string>(type: "VARCHAR2(3)", unicode: false, maxLength: 3, nullable: false),
                    DEGREE_TYPE_NAME = table.Column<string>(type: "VARCHAR2(25)", unicode: false, maxLength: 25, nullable: false),
                    DEGREE_LEVEL_CODE = table.Column<string>(type: "VARCHAR2(1)", unicode: false, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEGREE_TYPES", x => x.DEGREE_TYPE_CODE);
                    table.ForeignKey(
                        name: "FK_DEGREE_TYPES_DEGREE_TYPE_CD",
                        column: x => x.DEGREE_LEVEL_CODE,
                        principalSchema: "MARAT",
                        principalTable: "DEGREE_LEVELS",
                        principalColumn: "DEGREE_LEVEL_CODE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COURSES",
                schema: "MARAT",
                columns: table => new
                {
                    DEPARTMENT_CODE = table.Column<string>(type: "VARCHAR2(2)", unicode: false, maxLength: 2, nullable: false),
                    COURSE_NUMBER = table.Column<byte>(type: "NUMBER(3)", precision: 3, nullable: false),
                    COURSE_TITLE = table.Column<string>(type: "VARCHAR2(64)", unicode: false, maxLength: 64, nullable: false),
                    COURSE_DESCRIPTION = table.Column<string>(type: "VARCHAR2(512)", unicode: false, maxLength: 512, nullable: false),
                    CREDITS = table.Column<decimal>(type: "NUMBER(3,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COURSES", x => new { x.DEPARTMENT_CODE, x.COURSE_NUMBER });
                    table.ForeignKey(
                        name: "FK_COURSES_DEPARTMENT_CODE",
                        column: x => x.DEPARTMENT_CODE,
                        principalSchema: "MARAT",
                        principalTable: "DEPARTMENTS",
                        principalColumn: "DEPARTMENT_CODE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TERMS",
                schema: "MARAT",
                columns: table => new
                {
                    TERM_CODE = table.Column<string>(type: "VARCHAR2(6)", unicode: false, maxLength: 6, nullable: false),
                    SESSION_CODE = table.Column<string>(type: "VARCHAR2(2)", unicode: false, maxLength: 2, nullable: false),
                    YEAR = table.Column<byte>(type: "NUMBER(4)", precision: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TERMS", x => x.TERM_CODE);
                    table.ForeignKey(
                        name: "FK_SESSION_CODE",
                        column: x => x.SESSION_CODE,
                        principalSchema: "MARAT",
                        principalTable: "SESSIONS",
                        principalColumn: "SESSION_CODE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TABLE2",
                schema: "MARAT",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "NUMBER", nullable: false),
                    TESTTBID = table.Column<string>(type: "VARCHAR2(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TABLE2", x => x.ID);
                    table.ForeignKey(
                        name: "TABLE2_FK1",
                        column: x => x.ID,
                        principalSchema: "MARAT",
                        principalTable: "TESTTB",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DEGREES",
                schema: "MARAT",
                columns: table => new
                {
                    DEGREE_ID = table.Column<int>(type: "NUMBER(6)", precision: 6, nullable: false),
                    DEPARTMENT_CODE = table.Column<string>(type: "VARCHAR2(2)", unicode: false, maxLength: 2, nullable: false),
                    DEGREE_TYPE_CODE = table.Column<string>(type: "VARCHAR2(3)", unicode: false, maxLength: 3, nullable: false),
                    DEGREE_NAME = table.Column<string>(type: "VARCHAR2(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEGREES", x => x.DEGREE_ID);
                    table.ForeignKey(
                        name: "FK_DEGREES_DEGREE_TYPE_CODE",
                        column: x => x.DEGREE_TYPE_CODE,
                        principalSchema: "MARAT",
                        principalTable: "DEGREE_TYPES",
                        principalColumn: "DEGREE_TYPE_CODE",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DEGREES_DEPARTMENT_CODE",
                        column: x => x.DEPARTMENT_CODE,
                        principalSchema: "MARAT",
                        principalTable: "DEPARTMENTS",
                        principalColumn: "DEPARTMENT_CODE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "APPLICATIONS",
                schema: "MARAT",
                columns: table => new
                {
                    APPLICANT_ID = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    FIRST_NAME = table.Column<string>(type: "VARCHAR2(40)", unicode: false, maxLength: 40, nullable: false),
                    MIDDLE_NAME = table.Column<string>(type: "VARCHAR2(40)", unicode: false, maxLength: 40, nullable: false),
                    LAST_NAME = table.Column<string>(type: "VARCHAR2(40)", unicode: false, maxLength: 40, nullable: false),
                    GENDER = table.Column<string>(type: "VARCHAR2(1)", unicode: false, maxLength: 1, nullable: false),
                    STREET_ADDRESS = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    CITY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    STATE = table.Column<string>(type: "VARCHAR2(2)", unicode: false, maxLength: 2, nullable: false),
                    ZIP_CODE = table.Column<string>(type: "VARCHAR2(5)", unicode: false, maxLength: 5, nullable: false),
                    TELEPHONE = table.Column<string>(type: "VARCHAR2(20)", unicode: false, maxLength: 20, nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR2(80)", unicode: false, maxLength: 80, nullable: false),
                    DATE_OF_BIRTH = table.Column<DateTime>(type: "DATE", nullable: false),
                    GPA = table.Column<decimal>(type: "NUMBER(2,1)", nullable: true),
                    SAT_MATH_SCORE = table.Column<byte>(type: "NUMBER(3)", precision: 3, nullable: true),
                    SAT_READING_SCORE = table.Column<byte>(type: "NUMBER(3)", precision: 3, nullable: true),
                    SAT_WRITING_SCORE = table.Column<byte>(type: "NUMBER(3)", precision: 3, nullable: true),
                    RECEIVED_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    TERM_CODE = table.Column<string>(type: "VARCHAR2(6)", unicode: false, maxLength: 6, nullable: true),
                    APPLICATION_STATUS = table.Column<string>(type: "VARCHAR2(1)", unicode: false, maxLength: 1, nullable: false, defaultValueSql: "'N'  "),
                    POINTS = table.Column<decimal>(type: "NUMBER(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPLICATIONS", x => x.APPLICANT_ID);
                    table.ForeignKey(
                        name: "FK_APPLICATIONS_TERM_CODE",
                        column: x => x.TERM_CODE,
                        principalSchema: "MARAT",
                        principalTable: "TERMS",
                        principalColumn: "TERM_CODE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "APPLICATIONS_ONE_INDEX",
                schema: "MARAT",
                columns: table => new
                {
                    APPLICANT_ID = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    FIRST_NAME = table.Column<string>(type: "VARCHAR2(40)", unicode: false, maxLength: 40, nullable: false),
                    MIDDLE_NAME = table.Column<string>(type: "VARCHAR2(40)", unicode: false, maxLength: 40, nullable: false),
                    LAST_NAME = table.Column<string>(type: "VARCHAR2(40)", unicode: false, maxLength: 40, nullable: false),
                    GENDER = table.Column<string>(type: "VARCHAR2(1)", unicode: false, maxLength: 1, nullable: false),
                    STREET_ADDRESS = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    CITY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    STATE = table.Column<string>(type: "VARCHAR2(2)", unicode: false, maxLength: 2, nullable: false),
                    ZIP_CODE = table.Column<string>(type: "VARCHAR2(5)", unicode: false, maxLength: 5, nullable: false),
                    TELEPHONE = table.Column<string>(type: "VARCHAR2(20)", unicode: false, maxLength: 20, nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR2(80)", unicode: false, maxLength: 80, nullable: false),
                    DATE_OF_BIRTH = table.Column<DateTime>(type: "DATE", nullable: false),
                    GPA = table.Column<decimal>(type: "NUMBER(2,1)", nullable: true),
                    SAT_MATH_SCORE = table.Column<byte>(type: "NUMBER(3)", precision: 3, nullable: true),
                    SAT_READING_SCORE = table.Column<byte>(type: "NUMBER(3)", precision: 3, nullable: true),
                    SAT_WRITING_SCORE = table.Column<byte>(type: "NUMBER(3)", precision: 3, nullable: true),
                    RECEIVED_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    TERM_CODE = table.Column<string>(type: "VARCHAR2(6)", unicode: false, maxLength: 6, nullable: true),
                    APPLICATION_STATUS = table.Column<string>(type: "VARCHAR2(1)", unicode: false, maxLength: 1, nullable: false, defaultValueSql: "'N'  "),
                    POINTS = table.Column<decimal>(type: "NUMBER(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPLICATIONS_ONE", x => x.APPLICANT_ID);
                    table.ForeignKey(
                        name: "FK_APPLICATIONS_ONE_TERM_CODE",
                        column: x => x.TERM_CODE,
                        principalSchema: "MARAT",
                        principalTable: "TERMS",
                        principalColumn: "TERM_CODE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "APPLICATIONS_OVER_INDEXED",
                schema: "MARAT",
                columns: table => new
                {
                    APPLICANT_ID = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    FIRST_NAME = table.Column<string>(type: "VARCHAR2(40)", unicode: false, maxLength: 40, nullable: false),
                    MIDDLE_NAME = table.Column<string>(type: "VARCHAR2(40)", unicode: false, maxLength: 40, nullable: false),
                    LAST_NAME = table.Column<string>(type: "VARCHAR2(40)", unicode: false, maxLength: 40, nullable: false),
                    GENDER = table.Column<string>(type: "VARCHAR2(1)", unicode: false, maxLength: 1, nullable: false),
                    STREET_ADDRESS = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    CITY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    STATE = table.Column<string>(type: "VARCHAR2(2)", unicode: false, maxLength: 2, nullable: false),
                    ZIP_CODE = table.Column<string>(type: "VARCHAR2(5)", unicode: false, maxLength: 5, nullable: false),
                    TELEPHONE = table.Column<string>(type: "VARCHAR2(20)", unicode: false, maxLength: 20, nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR2(80)", unicode: false, maxLength: 80, nullable: false),
                    DATE_OF_BIRTH = table.Column<DateTime>(type: "DATE", nullable: false),
                    GPA = table.Column<decimal>(type: "NUMBER(2,1)", nullable: true),
                    SAT_MATH_SCORE = table.Column<byte>(type: "NUMBER(3)", precision: 3, nullable: true),
                    SAT_READING_SCORE = table.Column<byte>(type: "NUMBER(3)", precision: 3, nullable: true),
                    SAT_WRITING_SCORE = table.Column<byte>(type: "NUMBER(3)", precision: 3, nullable: true),
                    RECEIVED_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    TERM_CODE = table.Column<string>(type: "VARCHAR2(6)", unicode: false, maxLength: 6, nullable: true),
                    APPLICATION_STATUS = table.Column<string>(type: "VARCHAR2(1)", unicode: false, maxLength: 1, nullable: false, defaultValueSql: "'N'  "),
                    POINTS = table.Column<decimal>(type: "NUMBER(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPLICATIONS_OVR", x => x.APPLICANT_ID);
                    table.ForeignKey(
                        name: "FK_APPLICATIONS_OVR_TERM_CODE",
                        column: x => x.TERM_CODE,
                        principalSchema: "MARAT",
                        principalTable: "TERMS",
                        principalColumn: "TERM_CODE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COURSE_OFFERINGS",
                schema: "MARAT",
                columns: table => new
                {
                    COURSE_OFFERING_ID = table.Column<decimal>(type: "NUMBER(20)", nullable: false),
                    DEPARTMENT_CODE = table.Column<string>(type: "VARCHAR2(2)", unicode: false, maxLength: 2, nullable: false),
                    COURSE_NUMBER = table.Column<byte>(type: "NUMBER(3)", precision: 3, nullable: false),
                    TERM_CODE = table.Column<string>(type: "VARCHAR2(6)", unicode: false, maxLength: 6, nullable: false),
                    SECTION = table.Column<byte>(type: "NUMBER(3)", precision: 3, nullable: false),
                    CAPACITY = table.Column<byte>(type: "NUMBER(3)", precision: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COURSE_OFFERINGS", x => x.COURSE_OFFERING_ID);
                    table.ForeignKey(
                        name: "FK_COURSE_OFFERINGS_COURSES",
                        columns: x => new { x.DEPARTMENT_CODE, x.COURSE_NUMBER },
                        principalSchema: "MARAT",
                        principalTable: "COURSES",
                        principalColumns: new[] { "DEPARTMENT_CODE", "COURSE_NUMBER" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COURSE_OFFERINGS_TERM",
                        column: x => x.TERM_CODE,
                        principalSchema: "MARAT",
                        principalTable: "TERMS",
                        principalColumn: "TERM_CODE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DEGREE_REQUIREMENTS",
                schema: "MARAT",
                columns: table => new
                {
                    REQUIREMENT_ID = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    DEGREE_ID = table.Column<int>(type: "NUMBER(6)", precision: 6, nullable: false),
                    CLASS_STANDING_CODE = table.Column<string>(type: "VARCHAR2(2)", unicode: false, maxLength: 2, nullable: false),
                    SESSION_CODE = table.Column<string>(type: "VARCHAR2(2)", unicode: false, maxLength: 2, nullable: false),
                    DEPARTMENT_CODE = table.Column<string>(type: "VARCHAR2(2)", unicode: false, maxLength: 2, nullable: false),
                    COURSE_NUMBER = table.Column<byte>(type: "NUMBER(3)", precision: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEGREE_REQUIREMENTS", x => x.REQUIREMENT_ID);
                    table.ForeignKey(
                        name: "FK_DEGREE_REQ_CLASS_STNDG_CD",
                        column: x => x.CLASS_STANDING_CODE,
                        principalSchema: "MARAT",
                        principalTable: "CLASS_STANDINGS",
                        principalColumn: "CLASS_STANDING_CODE",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DEGREE_REQ_COURSES",
                        columns: x => new { x.DEPARTMENT_CODE, x.COURSE_NUMBER },
                        principalSchema: "MARAT",
                        principalTable: "COURSES",
                        principalColumns: new[] { "DEPARTMENT_CODE", "COURSE_NUMBER" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DEGREE_REQ_DEGREE_ID",
                        column: x => x.DEGREE_ID,
                        principalSchema: "MARAT",
                        principalTable: "DEGREES",
                        principalColumn: "DEGREE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DEGREE_REQ_SESSION_CD",
                        column: x => x.SESSION_CODE,
                        principalSchema: "MARAT",
                        principalTable: "SESSIONS",
                        principalColumn: "SESSION_CODE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STUDENTS",
                schema: "MARAT",
                columns: table => new
                {
                    STUDENT_ID = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    FIRST_NAME = table.Column<string>(type: "VARCHAR2(40)", unicode: false, maxLength: 40, nullable: false),
                    MIDDLE_NAME = table.Column<string>(type: "VARCHAR2(40)", unicode: false, maxLength: 40, nullable: false),
                    LAST_NAME = table.Column<string>(type: "VARCHAR2(40)", unicode: false, maxLength: 40, nullable: false),
                    GENDER = table.Column<string>(type: "VARCHAR2(1)", unicode: false, maxLength: 1, nullable: false),
                    STREET_ADDRESS = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    CITY = table.Column<string>(type: "VARCHAR2(30)", unicode: false, maxLength: 30, nullable: false),
                    STATE = table.Column<string>(type: "VARCHAR2(2)", unicode: false, maxLength: 2, nullable: false),
                    ZIP_CODE = table.Column<string>(type: "VARCHAR2(5)", unicode: false, maxLength: 5, nullable: false),
                    TELEPHONE = table.Column<string>(type: "VARCHAR2(20)", unicode: false, maxLength: 20, nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR2(80)", unicode: false, maxLength: 80, nullable: false),
                    DATE_OF_BIRTH = table.Column<DateTime>(type: "DATE", nullable: false),
                    DEGREE_PURSUED = table.Column<int>(type: "NUMBER(6)", precision: 6, nullable: false),
                    CLASS_STANDING_CODE = table.Column<string>(type: "VARCHAR2(2)", unicode: false, maxLength: 2, nullable: true),
                    STUDENT_STATUS = table.Column<string>(type: "VARCHAR2(1)", unicode: false, maxLength: 1, nullable: false),
                    ENROLLMENT_TERM = table.Column<string>(type: "VARCHAR2(6)", unicode: false, maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENTS", x => x.STUDENT_ID);
                    table.ForeignKey(
                        name: "FK_STUDENTS_CLASS_STANING",
                        column: x => x.CLASS_STANDING_CODE,
                        principalSchema: "MARAT",
                        principalTable: "CLASS_STANDINGS",
                        principalColumn: "CLASS_STANDING_CODE",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STUDENTS_DEGREE_PURSUED",
                        column: x => x.DEGREE_PURSUED,
                        principalSchema: "MARAT",
                        principalTable: "DEGREES",
                        principalColumn: "DEGREE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STUDENTS_ENROLLMENT_TERM",
                        column: x => x.ENROLLMENT_TERM,
                        principalSchema: "MARAT",
                        principalTable: "TERMS",
                        principalColumn: "TERM_CODE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COURSE_ENROLLMENTS",
                schema: "MARAT",
                columns: table => new
                {
                    COURSE_ENROLLMENT_ID = table.Column<decimal>(type: "NUMBER", nullable: false),
                    COURSE_OFFERING_ID = table.Column<decimal>(type: "NUMBER(20)", nullable: false),
                    STUDENT_ID = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: false),
                    GRADE_CODE = table.Column<string>(type: "VARCHAR2(1)", unicode: false, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COURSE_ENROLLMENTS", x => x.COURSE_ENROLLMENT_ID);
                    table.ForeignKey(
                        name: "FK_ENROLLMENTS_GRADES",
                        column: x => x.GRADE_CODE,
                        principalSchema: "MARAT",
                        principalTable: "GRADES",
                        principalColumn: "GRADE_CODE",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ENROLLMENTS_OFFERINGS",
                        column: x => x.COURSE_OFFERING_ID,
                        principalSchema: "MARAT",
                        principalTable: "COURSE_OFFERINGS",
                        principalColumn: "COURSE_OFFERING_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ENROLLMENTS_STUDENT",
                        column: x => x.STUDENT_ID,
                        principalSchema: "MARAT",
                        principalTable: "STUDENTS",
                        principalColumn: "STUDENT_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_APPLICANTS_STATE",
                schema: "MARAT",
                table: "APPLICATIONS",
                columns: new[] { "STATE", "LAST_NAME", "FIRST_NAME" });

            migrationBuilder.CreateIndex(
                name: "IX_APPLICATIONS_TERM_CODE",
                schema: "MARAT",
                table: "APPLICATIONS",
                column: "TERM_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_APPL_ONE_LAST_NAME",
                schema: "MARAT",
                table: "APPLICATIONS_ONE_INDEX",
                column: "LAST_NAME");

            migrationBuilder.CreateIndex(
                name: "IX_APPLICATIONS_ONE_INDEX_TERM_CODE",
                schema: "MARAT",
                table: "APPLICATIONS_ONE_INDEX",
                column: "TERM_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_APPL_OVR_CITY",
                schema: "MARAT",
                table: "APPLICATIONS_OVER_INDEXED",
                column: "CITY");

            migrationBuilder.CreateIndex(
                name: "IX_APPL_OVR_DOB",
                schema: "MARAT",
                table: "APPLICATIONS_OVER_INDEXED",
                column: "DATE_OF_BIRTH");

            migrationBuilder.CreateIndex(
                name: "IX_APPL_OVR_EMAIL",
                schema: "MARAT",
                table: "APPLICATIONS_OVER_INDEXED",
                column: "EMAIL");

            migrationBuilder.CreateIndex(
                name: "IX_APPL_OVR_FIRST_NAME",
                schema: "MARAT",
                table: "APPLICATIONS_OVER_INDEXED",
                column: "FIRST_NAME");

            migrationBuilder.CreateIndex(
                name: "IX_APPL_OVR_LAST_NAME",
                schema: "MARAT",
                table: "APPLICATIONS_OVER_INDEXED",
                column: "LAST_NAME");

            migrationBuilder.CreateIndex(
                name: "IX_APPL_OVR_MIDDLE_NAME",
                schema: "MARAT",
                table: "APPLICATIONS_OVER_INDEXED",
                column: "MIDDLE_NAME");

            migrationBuilder.CreateIndex(
                name: "IX_APPL_OVR_PHONE",
                schema: "MARAT",
                table: "APPLICATIONS_OVER_INDEXED",
                column: "TELEPHONE");

            migrationBuilder.CreateIndex(
                name: "IX_APPL_OVR_STATE",
                schema: "MARAT",
                table: "APPLICATIONS_OVER_INDEXED",
                column: "STATE");

            migrationBuilder.CreateIndex(
                name: "IX_APPL_OVR_STREET",
                schema: "MARAT",
                table: "APPLICATIONS_OVER_INDEXED",
                column: "STREET_ADDRESS");

            migrationBuilder.CreateIndex(
                name: "IX_APPL_OVR_ZIP_CODE",
                schema: "MARAT",
                table: "APPLICATIONS_OVER_INDEXED",
                column: "ZIP_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_APPLICATIONS_OVER_INDEXED_TERM_CODE",
                schema: "MARAT",
                table: "APPLICATIONS_OVER_INDEXED",
                column: "TERM_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_CLASS_STANDINGS_DEGREE_LEVEL_CODE",
                schema: "MARAT",
                table: "CLASS_STANDINGS",
                column: "DEGREE_LEVEL_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_COURSE_ENROLL_OFFERING",
                schema: "MARAT",
                table: "COURSE_ENROLLMENTS",
                columns: new[] { "COURSE_OFFERING_ID", "STUDENT_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_COURSE_ENROLLMENTS_GRADE_CODE",
                schema: "MARAT",
                table: "COURSE_ENROLLMENTS",
                column: "GRADE_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_COURSE_ENROLLMENTS_STUDENT_ID",
                schema: "MARAT",
                table: "COURSE_ENROLLMENTS",
                column: "STUDENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COURSE_OFFERINGS_DEPARTMENT_CODE_COURSE_NUMBER",
                schema: "MARAT",
                table: "COURSE_OFFERINGS",
                columns: new[] { "DEPARTMENT_CODE", "COURSE_NUMBER" });

            migrationBuilder.CreateIndex(
                name: "IX_COURSE_OFFERINGS_TERM_CODE",
                schema: "MARAT",
                table: "COURSE_OFFERINGS",
                column: "TERM_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_DEGREE_REQUIREMENTS_CLASS_STANDING_CODE",
                schema: "MARAT",
                table: "DEGREE_REQUIREMENTS",
                column: "CLASS_STANDING_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_DEGREE_REQUIREMENTS_DEGREE_ID",
                schema: "MARAT",
                table: "DEGREE_REQUIREMENTS",
                column: "DEGREE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DEGREE_REQUIREMENTS_DEPARTMENT_CODE_COURSE_NUMBER",
                schema: "MARAT",
                table: "DEGREE_REQUIREMENTS",
                columns: new[] { "DEPARTMENT_CODE", "COURSE_NUMBER" });

            migrationBuilder.CreateIndex(
                name: "IX_DEGREE_REQUIREMENTS_SESSION_CODE",
                schema: "MARAT",
                table: "DEGREE_REQUIREMENTS",
                column: "SESSION_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_DEGREE_TYPES_DEGREE_LEVEL_CODE",
                schema: "MARAT",
                table: "DEGREE_TYPES",
                column: "DEGREE_LEVEL_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_DEGREES_DEGREE_TYPE_CODE",
                schema: "MARAT",
                table: "DEGREES",
                column: "DEGREE_TYPE_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_DEGREES_DEPARTMENT_CODE",
                schema: "MARAT",
                table: "DEGREES",
                column: "DEPARTMENT_CODE");

            migrationBuilder.CreateIndex(
                name: "I_MLOG$_TAB1",
                schema: "MARAT",
                table: "MLOG$_TAB1",
                column: "XID$$");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENTS_CLASS_STANDING_CODE",
                schema: "MARAT",
                table: "STUDENTS",
                column: "CLASS_STANDING_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENTS_DEGREE_PURSUED",
                schema: "MARAT",
                table: "STUDENTS",
                column: "DEGREE_PURSUED");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENTS_ENROLLMENT_TERM",
                schema: "MARAT",
                table: "STUDENTS",
                column: "ENROLLMENT_TERM");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENTS_NAME_STATE",
                schema: "MARAT",
                table: "STUDENTS",
                column: "STATE",
                filter: "UPPER(\"LAST_NAME\")");

            migrationBuilder.CreateIndex(
                name: "IX_TERMS_SESSION_CODE",
                schema: "MARAT",
                table: "TERMS",
                column: "SESSION_CODE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APPLICATIONS",
                schema: "MARAT");

            migrationBuilder.DropTable(
                name: "APPLICATIONS_ONE_INDEX",
                schema: "MARAT");

            migrationBuilder.DropTable(
                name: "APPLICATIONS_OVER_INDEXED",
                schema: "MARAT");

            migrationBuilder.DropTable(
                name: "COURSE_ENROLLMENTS",
                schema: "MARAT");

            migrationBuilder.DropTable(
                name: "DEGREE_REQUIREMENTS",
                schema: "MARAT");

            migrationBuilder.DropTable(
                name: "IM_RECONSIGNMENT",
                schema: "MARAT");

            migrationBuilder.DropTable(
                name: "MLOG$_TAB1",
                schema: "MARAT");

            migrationBuilder.DropTable(
                name: "PERF_STATS",
                schema: "MARAT");

            migrationBuilder.DropTable(
                name: "PERFORMANCE_CAPTURE_STATS",
                schema: "MARAT");

            migrationBuilder.DropTable(
                name: "RUPD$_TAB1",
                schema: "MARAT");

            migrationBuilder.DropTable(
                name: "TAB1",
                schema: "MARAT");

            migrationBuilder.DropTable(
                name: "TABLE2",
                schema: "MARAT");

            migrationBuilder.DropTable(
                name: "TEST",
                schema: "MARAT");

            migrationBuilder.DropTable(
                name: "GRADES",
                schema: "MARAT");

            migrationBuilder.DropTable(
                name: "COURSE_OFFERINGS",
                schema: "MARAT");

            migrationBuilder.DropTable(
                name: "STUDENTS",
                schema: "MARAT");

            migrationBuilder.DropTable(
                name: "TESTTB",
                schema: "MARAT");

            migrationBuilder.DropTable(
                name: "COURSES",
                schema: "MARAT");

            migrationBuilder.DropTable(
                name: "CLASS_STANDINGS",
                schema: "MARAT");

            migrationBuilder.DropTable(
                name: "DEGREES",
                schema: "MARAT");

            migrationBuilder.DropTable(
                name: "TERMS",
                schema: "MARAT");

            migrationBuilder.DropTable(
                name: "DEGREE_TYPES",
                schema: "MARAT");

            migrationBuilder.DropTable(
                name: "DEPARTMENTS",
                schema: "MARAT");

            migrationBuilder.DropTable(
                name: "SESSIONS",
                schema: "MARAT");

            migrationBuilder.DropTable(
                name: "DEGREE_LEVELS",
                schema: "MARAT");

            migrationBuilder.DropSequence(
                name: "SEQ_PERFORMANCE_CAPTURE",
                schema: "MARAT");

            migrationBuilder.DropSequence(
                name: "TABLE1_SEQ",
                schema: "MARAT");

            migrationBuilder.DropSequence(
                name: "TABLE2_SEQ",
                schema: "MARAT");
        }
    }
}
