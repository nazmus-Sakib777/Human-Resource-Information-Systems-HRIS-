using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS_R62.Migrations
{
    /// <inheritdoc />
    public partial class SpAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
             CREATE PROCEDURE spInsertSalaryGrade
                @SalaryGradeID NVARCHAR(50),
                @GradeName NVARCHAR(50),
                @GradeStatus NVARCHAR(50),
                @RuleName NVARCHAR(50),
                @EffectiveDate DATE,
                @GradeID NVARCHAR(50)
            AS
            BEGIN
                SET NOCOUNT ON;

                INSERT INTO SalaryGrades (
                    SalaryGradeID,
                    GradeName,
                    GradeStatus,
                    RuleName,
                    EffectiveDate,
                    GradeID
                )
                VALUES (
                    @SalaryGradeID,
                    @GradeName,
                    @GradeStatus,
                    @RuleName,
                    @EffectiveDate,
                    @GradeID
                );
            END;
            ");

            migrationBuilder.Sql(@"
            CREATE PROCEDURE spInsertSalaryDeduction
                    @SalaryDeductionID NVARCHAR(50),
                    @Amount DECIMAL(18,2),
                    @DeductionDate DATE,
                    @ActivationDate DATE,
                    @Reason NVARCHAR(100),
                    @LocalAreaClerance NVARCHAR(20),
                    @LocalAreaRemarks NVARCHAR(100),
                    @ApprovedDate DATE,
                    @EntryUser NVARCHAR(50),
                    @EntryDate DATE,
                    @EmployeeID NVARCHAR(50)
                AS
                BEGIN
                    SET NOCOUNT ON;

                    INSERT INTO SalaryDeductions (
                        SalaryDeductionID,
                        Amount,
                        DeductionDate,
                        ActivationDate,
                        Reason,
                        LocalAreaClerance,
                        LocalAreaRemarks,
                        ApprovedDate,
                        EntryUser,
                        EntryDate,
                        EmployeeID
                    )
                    VALUES (
                        @SalaryDeductionID,
                        @Amount,
                        @DeductionDate,
                        @ActivationDate,
                        @Reason,
                        @LocalAreaClerance,
                        @LocalAreaRemarks,
                        @ApprovedDate,
                        @EntryUser,
                        @EntryDate,
                        @EmployeeID
                    );
                END;
");

            migrationBuilder.Sql(@"
           CREATE PROCEDURE spInsertSalaryEntry
    @SalaryEntryID NVARCHAR(50),
    @ApplyDate DATE,
    @SalaryHeadName NVARCHAR(50),
    @Amount DECIMAL(18,2),
    @EmployeeID NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO SalaryEntrys (
        SalaryEntryID,
        ApplyDate,
        SalaryHeadName,
        Amount,
        EmployeeID
    )
    VALUES (
        @SalaryEntryID,
        @ApplyDate,
        @SalaryHeadName,
        @Amount,
        @EmployeeID
    );
END;
");

            migrationBuilder.Sql(@"
                    CREATE PROCEDURE spInsertSalaryProcess
                            @ProcessID NVARCHAR(50),
                            @MonthNo INT,
                            @YearNo INT,
                            @FromDate DATE,
                            @ToDate DATE,
                            @SalaryHeadName NVARCHAR(50),
                            @Amount DECIMAL(18,2),
                            @Type NVARCHAR(6),
                            @ProcessDate DATE,
                            @ProcessedBy NVARCHAR(50),
                            @EmployeeID NVARCHAR(50),
                            @SalaryEntryID NVARCHAR(50)
                        AS
                        BEGIN
                            SET NOCOUNT ON;

                            INSERT INTO SalaryProcesss (
                                ProcessID,
                                MonthNo,
                                YearNo,
                                FromDate,
                                ToDate,
                                SalaryHeadName,
                                Amount,
                                Type,
                                ProcessDate,
                                ProcessedBy,
                                EmployeeID,
                                SalaryEntryID
                            )
                            VALUES (
                                @ProcessID,
                                @MonthNo,
                                @YearNo,
                                @FromDate,
                                @ToDate,
                                @SalaryHeadName,
                                @Amount,
                                @Type,
                                @ProcessDate,
                                @ProcessedBy,
                                @EmployeeID,
                                @SalaryEntryID
                            )
                        END;
                    ");

            migrationBuilder.Sql(@"
                        CREATE PROCEDURE spInsertSalaryRecord
                            @SalaryRecordID NVARCHAR(50),
                            @SalaryStartDate DATE,
                            @SalaryEndDate DATE,
                            @JoiningDate DATE,
                            @MonthDays INT,
                            @PunchDays INT,
                            @TotalHoliDay INT,
                            @TotalLeave INT,
                            @WorkingDays INT,
                            @Absenteeism DECIMAL(18,2),
                            @Gross DECIMAL(18,2),
                            @ActualGross DECIMAL(18,2),
                            @Basic DECIMAL(18,2),
                            @HouseRent DECIMAL(18,2),
                            @MedicalAllowance DECIMAL(18,2),
                            @MobileAllowance DECIMAL(18,2),
                            @OtherAllowances DECIMAL(18,2),
                            @LunchAllowance DECIMAL(18,2),
                            @Tax DECIMAL(18,2),
                            @OtherDeduction DECIMAL(18,2),
                            @OTHours DECIMAL(18,2),
                            @OTAmount DECIMAL(18,2),
                            @ByBankAmount DECIMAL(18,2),
                            @ByCashAmount DECIMAL(18,2),
                            @NetPayable DECIMAL(18,2),
                            @ConveyanceAllowance DECIMAL(18,2),
                            @AttendanceBonus DECIMAL(18,2),
                            @SpecialAllowance DECIMAL(18,2),
                            @SalaryAdvance DECIMAL(18,2),
                            @FoodCharge DECIMAL(18,2),
                            @OTRate DECIMAL(18,2),
                            @TiffinAllowance DECIMAL(18,2),
                            @Arrear DECIMAL(18,2),
                            @SpecialBonus DECIMAL(18,2),
                            @LeaveStatus NVARCHAR(50),
                            @HoliDayBillAmount DECIMAL(18,2),
                            @NightBillAmount DECIMAL(18,2),
                            @SalaryID INT,
                            @LunchBillAmount DECIMAL(18,2),
                            @MobileBanking BIT,
                            @AccountNumber NVARCHAR(50),
                            @BankName NVARCHAR(50),
                            @ProcessDate DATE,
                            @UnitID NVARCHAR(50),
                            @SectionID NVARCHAR(50),
                            @EmploymentTypeID NVARCHAR(50),
                            @SalaryGradeID NVARCHAR(50),
                            @CompanyID NVARCHAR(50),
                            @DepartmentID NVARCHAR(50),
                            @DesignationID NVARCHAR(50),
                            @GradeID NVARCHAR(50)
                        AS
                        BEGIN
	                        SET NOCOUNT ON;
                            INSERT INTO SalaryRecords (
                                SalaryRecordID, SalaryStartDate, SalaryEndDate, JoiningDate, MonthDays, PunchDays, 
                                TotalHoliDay, TotalLeave, WorkingDays, Absenteeism, Gross, ActualGross, Basic, 
                                HouseRent, MedicalAllowance, MobileAllowance, OtherAllowances, LunchAllowance, Tax, 
                                OtherDeduction, OTHours, OTAmount, ByBankAmount, ByCashAmount, NetPayable, 
                                ConveyanceAllowance, AttendanceBonus, SpecialAllowance, SalaryAdvance, FoodCharge, 
                                OTRate, TiffinAllowance, Arrear, SpecialBonus, LeaveStatus, HoliDayBillAmount, 
                                NightBillAmount, SalaryID, LunchBillAmount, MobileBanking, AccountNumber, BankName, 
                                ProcessDate, UnitID, SectionID, EmploymentTypeID, SalaryGradeID, CompanyID, 
                                DepartmentID, DesignationID, GradeID
                            )
                            VALUES (
                                @SalaryRecordID, @SalaryStartDate, @SalaryEndDate, @JoiningDate, @MonthDays, @PunchDays, 
                                @TotalHoliDay, @TotalLeave, @WorkingDays, @Absenteeism, @Gross, @ActualGross, @Basic, 
                                @HouseRent, @MedicalAllowance, @MobileAllowance, @OtherAllowances, @LunchAllowance, @Tax, 
                                @OtherDeduction, @OTHours, @OTAmount, @ByBankAmount, @ByCashAmount, @NetPayable, 
                                @ConveyanceAllowance, @AttendanceBonus, @SpecialAllowance, @SalaryAdvance, @FoodCharge, 
                                @OTRate, @TiffinAllowance, @Arrear, @SpecialBonus, @LeaveStatus, @HoliDayBillAmount, 
                                @NightBillAmount, @SalaryID, @LunchBillAmount, @MobileBanking, @AccountNumber, @BankName, 
                                @ProcessDate, @UnitID, @SectionID, @EmploymentTypeID, @SalaryGradeID, @CompanyID, 
                                @DepartmentID, @DesignationID, @GradeID
                            )
                        END;
                    ");

            migrationBuilder.Sql(@"
                        CREATE PROCEDURE sp_InsertBonusRecord
                            @BonusRecordID NVARCHAR(50),
                            @BonusDate DATE,
                            @JoiningDate DATE,
                            @BasicSalary DECIMAL(18,2),
                            @HouseRent DECIMAL(18,2),
                            @MedicalAllowance DECIMAL(18,2),
                            @ConveyanceAllowance NVARCHAR(50),
                            @OtherAllowance NVARCHAR(50),
                            @GrossSalary DECIMAL(18,2),
                            @BonusPercent DECIMAL(18,2),
                            @BonusAmount DECIMAL(18,2),
                            @FestivalName NVARCHAR(50),
                            @RevenueStampAmount DECIMAL(18,2),
                            @NetPayableAmount DECIMAL(18,2),
                            @EmployeeID NVARCHAR(50)
                        AS
                        BEGIN
	                        SET NOCOUNT ON;
                            INSERT INTO BonusRecords (
                                BonusRecordID,
                                BonusDate,
                                JoiningDate,
                                BasicSalary,
                                HouseRent,
                                MedicalAllowance,
                                ConveyanceAllowance,
                                OtherAllowance,
                                GrossSalary,
                                BonusPercent,
                                BonusAmount,
                                FestivalName,
                                RevenueStampAmount,
                                NetPayableAmount,
                                EmployeeID
                            )
                            VALUES (
                                @BonusRecordID,
                                @BonusDate,
                                @JoiningDate,
                                @BasicSalary,
                                @HouseRent,
                                @MedicalAllowance,
                                @ConveyanceAllowance,
                                @OtherAllowance,
                                @GrossSalary,
                                @BonusPercent,
                                @BonusAmount,
                                @FestivalName,
                                @RevenueStampAmount,
                                @NetPayableAmount,
                                @EmployeeID
                            )
                        END
                    ");

            migrationBuilder.Sql(@"
                        CREATE PROCEDURE sp_InsertFestivalBonus
                            @FestivalBonusID NVARCHAR(50),
                            @FestivalName NVARCHAR(50),
                            @PercentageBelowOneYear DECIMAL(5,2),
                            @PercentageAfterOneYear DECIMAL(5,2),
                            @BonusEligibilityCheck INT,
                            @FestivalBonusDate DATE,
                            @EffectiveFrom DATE,
                            @EffectiveTo DATE,
                            @LastUpdated DATE,
                            @UpdatedBy NVARCHAR(50),
                            @EmployeeID NVARCHAR(50)
                        AS
                        BEGIN
                            SET NOCOUNT ON;

                            INSERT INTO FestivalBonuses (
                                FestivalBonusID,
                                FestivalName,
                                PercentageBelowOneYear,
                                PercentageAfterOneYear,
                                BonusEligibilityCheck,
                                FestivalBonusDate,
                                EffectiveFrom,
                                EffectiveTo,
                                LastUpdated,
                                UpdatedBy,
                                EmployeeID
                            )
                            VALUES (
                                @FestivalBonusID,
                                @FestivalName,
                                @PercentageBelowOneYear,
                                @PercentageAfterOneYear,
                                @BonusEligibilityCheck,
                                @FestivalBonusDate,
                                @EffectiveFrom,
                                @EffectiveTo,
                                @LastUpdated,
                                @UpdatedBy,
                                @EmployeeID
                            );
                        END
                    ");

            migrationBuilder.Sql(@"
                        CREATE PROCEDURE sp_InsertFoodCharge
                            @FoodChargeID NVARCHAR(50),
                            @ChargeDate DATE,
                            @ChargeAmount DECIMAL(18,2),
                            @ChargeType NVARCHAR(20),
                            @Status NVARCHAR(20),
                            @EntryDate DATE,
                            @EntryUser NVARCHAR(50),
                            @EmployeeID NVARCHAR(50)
                        AS
                        BEGIN
                            SET NOCOUNT ON;

                            INSERT INTO FoodCharges (
                                FoodChargeID,
                                ChargeDate,
                                ChargeAmount,
                                ChargeType,
                                Status,
                                EntryDate,
                                EntryUser,
                                EmployeeID
                            )
                            VALUES (
                                @FoodChargeID,
                                @ChargeDate,
                                @ChargeAmount,
                                @ChargeType,
                                @Status,
                                @EntryDate,
                                @EntryUser,
                                @EmployeeID
                            )
                        END
                    ");

            migrationBuilder.Sql(@"
                        CREATE PROCEDURE sp_InsertTiffinAllowanceRate
                            @TiffinAllowanceRateID NVARCHAR(50),
                            @RateInTaka DECIMAL(18,2),
                            @DesignationID NVARCHAR(50)
                        AS
                        BEGIN
                            SET NOCOUNT ON;

                            INSERT INTO TiffinAllowanceRates (
                                TiffinAllowanceRateID,
                                RateInTaka,
                                DesignationID
                            )
                            VALUES (
                                @TiffinAllowanceRateID,
                                @RateInTaka,
                                @DesignationID
                            )
                        END
                    ");

            migrationBuilder.Sql(@"
                    CREATE PROCEDURE sp_InsertTiffinAllowanceTime
                        @TiffinAllowanceID NVARCHAR(50),
                        @AllowanceDate DATE,
                        @AllowanceType NVARCHAR(10),
                        @Time TIME,
                        @EmploymentTypeID NVARCHAR(50)
                    AS
                    BEGIN
                        SET NOCOUNT ON;

                        INSERT INTO TiffinAllowanceTimes (
                            TiffinAllowanceID,
                            AllowanceDate,
                            AllowanceType,
                            Time,
                            EmploymentTypeID
                        )
                        VALUES (
                            @TiffinAllowanceID,
                            @AllowanceDate,
                            @AllowanceType,
                            @Time,
                            @EmploymentTypeID
                        )
                    END
                    ");

            migrationBuilder.Sql(@"
                    CREATE PROCEDURE sp_InsertNightAllowance
                        @NightAllowanceID NVARCHAR(50),
                        @SalaryMinimum MONEY,
                        @SalaryMaximum MONEY,
                        @NightAllowanceRate NVARCHAR(MAX),
                        @EmploymentTypeID NVARCHAR(50)
                    AS
                    BEGIN
                        SET NOCOUNT ON;

                        INSERT INTO NightAllowances (
                            NightAllowanceID,
                            SalaryMinimum,
                            SalaryMaximum,
                            NightAllowanceRate,
                            EmploymentTypeID
                        )
                        VALUES (
                            @NightAllowanceID,
                            @SalaryMinimum,
                            @SalaryMaximum,
                            @NightAllowanceRate,
                            @EmploymentTypeID
                        )
                    END
                    ");

            migrationBuilder.Sql(@"
                        CREATE PROCEDURE sp_InsertNightAllowanceTime
                            @NightAllowanceTimeID NVARCHAR(50),
                            @StartDate DATE,
                            @EndDate DATE,
                            @AllowanceType NVARCHAR(10),
                            @NightHours NVARCHAR(50),
                            @NightMinutes NVARCHAR(50),
                            @EmploymentTypeID NVARCHAR(50)
                        AS
                        BEGIN
                            SET NOCOUNT ON;

                            INSERT INTO NightAllowanceTimes (
                                NightAllowanceTimeID,
                                StartDate,
                                EndDate,
                                AllowanceType,
                                NightHours,
                                NightMinutes,
                                EmploymentTypeID
                            )
                            VALUES (
                                @NightAllowanceTimeID,
                                @StartDate,
                                @EndDate,
                                @AllowanceType,
                                @NightHours,
                                @NightMinutes,
                                @EmploymentTypeID
                            )
                        END
                    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
