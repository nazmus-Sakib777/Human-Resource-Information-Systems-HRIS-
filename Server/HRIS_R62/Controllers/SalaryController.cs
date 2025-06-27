
using HRIS_R62.Models;
using HRIS_R62.RepoForSp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace HRIS_R62.Controllers
{
 
   
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private ApplicationDbContext _context;
        private readonly ISalaryGradeRepository _repository;
        private readonly ISalaryDeductionRepository _deductionRepository;
        private readonly ISalaryEntryRepository _entryRepository;
        private readonly ISalaryProcessRepository _processRepository;
        private readonly ISalaryRecordRepository _salaryRecordRepository;
        private readonly IBonusRecordRepository _iBonusRecordRepository;
        private readonly IFestivalBonusRepository _iFestivalBonusRepository;
        private readonly IFoodChargeRepository _fcr;
        private readonly ITiffinAllowanceRateRepository _tar;
        private readonly ITiffinAllowanceTimeRepository _tat;
        private readonly INightAllowanceTimeRepository _nat;
        private readonly INightAllowanceRepository _na;

        public SalaryController(
            ApplicationDbContext context, 
            ISalaryGradeRepository repository, 
            ISalaryDeductionRepository deductionRepository,
            ISalaryEntryRepository entryRepository,
            ISalaryProcessRepository processRepository,
            ISalaryRecordRepository salaryRecordRepository,
            IBonusRecordRepository iBonusRecordRepository,
            IFestivalBonusRepository iFestivalBonusRepository,
            IFoodChargeRepository fcr,
            ITiffinAllowanceRateRepository tar,
            ITiffinAllowanceTimeRepository tat,
            INightAllowanceTimeRepository nat,
            INightAllowanceRepository na)
        {
            _context = context;
            _repository = repository;
            _deductionRepository = deductionRepository;
            _entryRepository = entryRepository;
            _processRepository = processRepository;
            _salaryRecordRepository = salaryRecordRepository;
            _iBonusRecordRepository = iBonusRecordRepository;
            _iFestivalBonusRepository = iFestivalBonusRepository;
            _fcr = fcr;
            _tar = tar;
            _tat = tat;
            _nat = nat;
            _na = na;
        }

        //-----------------------------------------SalaryGrade-----------------------------------------------------


        //GetAlSalaryGrade
        [HttpGet("salaryGrade")]
        public async Task<ActionResult<IEnumerable<SalaryGrade>>> GetSalaryGrades()
        {
            return await _context.SalaryGrades.ToListAsync();
        }


        //GetByID

        [HttpGet("salaryGrade/{id}")]
        public async Task<ActionResult<SalaryGrade>> GetSalaryGrade(string id)
        {
            var salaryGrade = await _context.SalaryGrades.FindAsync(id);
            if (salaryGrade == null) return NotFound();
            return salaryGrade;
        }

        //SalaryGradeInsertWithSp

        [HttpPost("salaryGrade")]
        public async Task<IActionResult> PostSalaryGrade(SalaryGrade grade)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repository.InsertAsync(grade);
            return Ok(new { message = "SalaryGrade inserted successfully." });
        }

        //SalaryGradeUpdate

        [HttpPut("salaryGrade/{id}")]
        public async Task<IActionResult> PutSalaryGrade(string id, SalaryGrade salaryGrade)
        {
            if (id != salaryGrade.SalaryGradeID) return BadRequest();

            _context.Entry(salaryGrade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.SalaryGrades.Any(e => e.SalaryGradeID == id)) return NotFound();
                throw;
            }

            return NoContent();
        }


        //SalaryGradeDelete

        [HttpDelete("salaryGrade/{id}")]
        public async Task<IActionResult> DeleteSalaryGrade(string id)
        {
            var salaryGrade = await _context.SalaryGrades.FindAsync(id);
            if (salaryGrade == null) return NotFound();

            _context.SalaryGrades.Remove(salaryGrade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //------------------------------------SalaryDeduction-------------------------------------


        [HttpGet("SalaryDeduction")]
        public async Task<ActionResult<IEnumerable<SalaryDeduction>>> GetSalaryDeductions()
        {
            return await _context.SalaryDeductions.ToListAsync();
        }

        [HttpGet("SalaryDeduction{id}")]
        public async Task<ActionResult<SalaryDeduction>> GetSalaryDeductionById(string id)
        {
            var salaryDeduction = await _context.SalaryDeductions.FindAsync(id);

            if (salaryDeduction == null)
            {
                return NotFound();
            }

            return salaryDeduction;
        }


        [HttpPost("SalaryDeduction")]
        public async Task<IActionResult> PostSalaryDeduction(SalaryDeduction deduction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _deductionRepository.InsertAsync(deduction);
            return Ok(new { message = "Salary Deduction inserted successfully." });
        }


        [HttpPut("SalaryDeduction{id}")]
        public async Task<IActionResult> PutSalaryDeduction(string id, SalaryDeduction salaryDeduction)
        {
            if (id != salaryDeduction.SalaryDeductionID)
            {
                return BadRequest();
            }

            _context.Entry(salaryDeduction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryDeductionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpDelete("SalaryDeduction{id}")]
        public async Task<IActionResult> DeleteSalaryDeduction(string id)
        {
            var salaryDeduction = await _context.SalaryDeductions.FindAsync(id);
            if (salaryDeduction == null)
            {
                return NotFound();
            }

            _context.SalaryDeductions.Remove(salaryDeduction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalaryDeductionExists(string id)
        {
            return _context.SalaryDeductions.Any(e => e.SalaryDeductionID == id);
        }


        //--------------------------------------SalaryEntry-----------------------------------------------------------------------

        [HttpGet("SalaryEntry")]
        public async Task<ActionResult<IEnumerable<SalaryEntry>>> GetSalaryEntries()
        {
            return await _context.SalaryEntrys.ToListAsync();
        }

        [HttpGet("SalaryEntry{id}")]
        public async Task<ActionResult<SalaryEntry>> GetSalaryEntry(string id)
        {
            var entry = await _context.SalaryEntrys.FindAsync(id);
            if (entry == null)
                return NotFound();

            return entry;
        }


        [HttpPost("SalaryEntry")]
        public async Task<IActionResult> PostSalaryEntry(SalaryEntry entry)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _entryRepository.InsertAsync(entry);
            return Ok(new { message = "Salary Entry inserted successfully." });
        }


        [HttpPut("SalaryEntry{id}")]
        public async Task<IActionResult> UpdateSalaryEntry(string id, SalaryEntry entry)
        {
            if (id != entry.SalaryEntryID)
                return BadRequest();

            _context.Entry(entry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryEntryExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }


        [HttpDelete("SalaryEntry{id}")]
        public async Task<IActionResult> DeleteSalaryEntry(string id)
        {
            var entry = await _context.SalaryEntrys.FindAsync(id);
            if (entry == null)
                return NotFound();

            _context.SalaryEntrys.Remove(entry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalaryEntryExists(string id)
        {
            return _context.SalaryEntrys.Any(e => e.SalaryEntryID == id);
        }

        //----------------------------------------SalaryProcess-----------------------------------------------------

        [HttpGet("SalaryProcess")]
        public async Task<ActionResult<IEnumerable<SalaryProcess>>> GetSalaryProcesses()
        {
            return await _context.SalaryProcesss.ToListAsync();
        }

        [HttpGet("SalaryProcess{id}")]
        public async Task<ActionResult<SalaryProcess>> GetSalaryProcess(string id)
        {
            var process = await _context.SalaryProcesss.FindAsync(id);
            if (process == null)
                return NotFound();

            return process;
        }

        [HttpPost("SalaryProcess")]
        public async Task<IActionResult> PostSalaryProcess(SalaryProcess process)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _processRepository.InsertAsync(process);
            return Ok(new { message = "SalaryProcess inserted successfully." });
        }


        [HttpPut("SalaryProcess{id}")]
        public async Task<IActionResult> UpdateSalaryProcess(string id, SalaryProcess process)
        {
            if (id != process.ProcessID)
                return BadRequest();

            _context.Entry(process).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryProcessExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }


        [HttpDelete("SalaryProcess{id}")]
        public async Task<IActionResult> DeleteSalaryProcess(string id)
        {
            var process = await _context.SalaryProcesss.FindAsync(id);
            if (process == null)
                return NotFound();

            _context.SalaryProcesss.Remove(process);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalaryProcessExists(string id)
        {
            return _context.SalaryProcesss.Any(e => e.ProcessID == id);
        }

        //------------------------------------------SalaryRecord----------------------------------------------------
        
        [HttpGet("SalaryRecord")]
        public async Task<ActionResult<IEnumerable<SalaryRecord>>> GetSalaryRecords()
        {
            return await _context.SalaryRecords.ToListAsync();
        }

        [HttpGet("SalaryRecord{id}")]
        public async Task<ActionResult<SalaryRecord>> GetSalaryRecord(string id)
        {
            var record = await _context.SalaryRecords.FindAsync(id);
            if (record == null)
                return NotFound();

            return record;
        }

        [HttpPost("SalaryRecord")]
        public async Task<IActionResult> InsertSalaryRecord([FromBody] SalaryRecord record)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _salaryRecordRepository.InsertAsync(record);
            return Ok(new { message = "SalaryRecord inserted successfully." });
        }

        [HttpPut("SalaryRecord{id}")]
        public async Task<IActionResult> UpdateSalaryRecord(string id, SalaryRecord record)
        {
            if (id != record.SalaryRecordID)
                return BadRequest();

            _context.Entry(record).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.SalaryRecords.Any(e => e.SalaryRecordID == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("SalaryRecord{id}")]
        public async Task<IActionResult> DeleteSalaryRecord(string id)
        {
            var record = await _context.SalaryRecords.FindAsync(id);
            if (record == null)
                return NotFound();

            _context.SalaryRecords.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        //------------------------------------------BonusRecord----------------------------------------------------

        [HttpGet("BonusRecord")]
        public async Task<ActionResult<IEnumerable<BonusRecord>>> GetAllBonusRecord()
        {
            return await _context.BonusRecords.ToListAsync();
        }

        [HttpGet("BonusRecord{id}")]
        public async Task<ActionResult<BonusRecord>> GetBonusRecordByID(string id)
        {
            var record = await _context.BonusRecords.FindAsync(id);
            if (record == null) return NotFound();
            return record;
        }

        [HttpPost("BonusRecord")]
        public async Task<IActionResult> CreateBonusRecord([FromBody] BonusRecord record)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _iBonusRecordRepository.InsertBonusRecordAsync(record);
            return Ok(new { message = "Bonus record inserted successfully" });
        }

        [HttpPut("BonusRecord{id}")]
        public async Task<IActionResult> UpdateBonusRecord(string id, BonusRecord record)
        {
            if (id != record.BonusRecordID) return BadRequest();

            _context.Entry(record).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.BonusRecords.Any(e => e.BonusRecordID == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("BonusRecord{id}")]
        public async Task<IActionResult> DeleteBonusRecord(string id)
        {
            var record = await _context.BonusRecords.FindAsync(id);
            if (record == null) return NotFound();

            _context.BonusRecords.Remove(record);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        //------------------------------------------FestivalBonus-------------------------------------------------------

        [HttpGet("FestivalBonus")]
        public async Task<ActionResult<IEnumerable<FestivalBonus>>> GetAllFestivalBonus()
        {
            return await _context.FestivalBonuses.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FestivalBonus>> GetFestivalBonusById(string id)
        {
            var bonus = await _context.FestivalBonuses.FindAsync(id);
            if (bonus == null) return NotFound();
            return bonus;
        }

        [HttpPost("FestivalBonus")]
        public async Task<IActionResult> CreateFestivalBonus([FromBody] FestivalBonus bonus)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _iFestivalBonusRepository.InsertFestivalBonusAsync(bonus);
            return Ok(new { message = "Festival bonus inserted successfully" });
        }

        [HttpPut("FestivalBonus{id}")]
        public async Task<IActionResult> UpdateFestivalBonus(string id, FestivalBonus bonus)
        {
            if (id != bonus.FestivalBonusID) return BadRequest();

            _context.Entry(bonus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.FestivalBonuses.Any(e => e.FestivalBonusID == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("FestivalBonus{id}")]
        public async Task<IActionResult> DeleteFestivalBonus(string id)
        {
            var bonus = await _context.FestivalBonuses.FindAsync(id);
            if (bonus == null) return NotFound();

            _context.FestivalBonuses.Remove(bonus);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //------------------------------------------FoodCharge-------------------------------------------------------

        [HttpGet("FoodCharge")]
        public async Task<ActionResult<IEnumerable<FoodCharge>>> GetAllFoodCharge()
        {
            return await _context.FoodCharges.ToListAsync();
        }

        [HttpGet("FoodCharge{id}")]
        public async Task<ActionResult<FoodCharge>> GetFoodChargeById(string id)
        {
            var charge = await _context.FoodCharges.FindAsync(id);
            if (charge == null) return NotFound();
            return charge;
        }

        [HttpPost("FoodCharge")]
        public async Task<IActionResult> CreateFoodCharge([FromBody] FoodCharge charge)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _fcr.InsertFoodChargeAsync(charge);
            return Ok(new { message = "Food charge inserted successfully" });
        }

        [HttpPut("FoodCharge{id}")]
        public async Task<IActionResult> UpdateFoodCharge(string id, FoodCharge charge)
        {
            if (id != charge.FoodChargeID)
                return BadRequest();

            _context.Entry(charge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.FoodCharges.Any(e => e.FoodChargeID == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("FoodCharge{id}")]
        public async Task<IActionResult> DeleteFoodCharge(string id)
        {
            var charge = await _context.FoodCharges.FindAsync(id);
            if (charge == null) return NotFound();

            _context.FoodCharges.Remove(charge);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //------------------------------------------TiffinAllowanceRate-------------------------------------------------------

        [HttpGet("TiffinAllowanceRate")]
        public async Task<ActionResult<IEnumerable<TiffinAllowanceRate>>> GetAllTiffinAllowanceRate()
        {
            return await _context.TiffinAllowanceRates.ToListAsync();
        }

        [HttpGet("TiffinAllowanceRate{id}")]
        public async Task<ActionResult<TiffinAllowanceRate>> TiffinAllowanceRate(string id)
        {
            var record = await _context.TiffinAllowanceRates.FindAsync(id);
            if (record == null)
                return NotFound();

            return record;
        }

        [HttpPost("TiffinAllowanceRate")]
        public async Task<IActionResult> CreateTiffinAllowanceRate([FromBody] TiffinAllowanceRate tiffinAllowanceRate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _tar.InsertTiffinAllowanceRateAsync(tiffinAllowanceRate);
            return Ok(new { message = "Tiffin allowance rate inserted successfully" });
        }

        [HttpPut("TiffinAllowanceRate{id}")]
        public async Task<IActionResult> UpdateTiffinAllowanceRate(string id, TiffinAllowanceRate rate)
        {
            if (id != rate.TiffinAllowanceRateID)
                return BadRequest();

            _context.Entry(rate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TiffinAllowanceRates.Any(e => e.TiffinAllowanceRateID == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("TiffinAllowanceRate{id}")]
        public async Task<IActionResult> DeleteTiffinAllowanceRate(string id)
        {
            var record = await _context.TiffinAllowanceRates.FindAsync(id);
            if (record == null)
                return NotFound();

            _context.TiffinAllowanceRates.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        //------------------------------------------TiffinAllowanceTime-------------------------------------------------------

        [HttpGet("TiffinAllowanceTime")]
        public async Task<ActionResult<IEnumerable<TiffinAllowanceTime>>> GetAllTiffinAllowanceTime()
        {
            return await _context.TiffinAllowanceTimes.ToListAsync();
        }


        [HttpGet("TiffinAllowanceTime{id}")]
        public async Task<ActionResult<TiffinAllowanceTime>> GetTiffinAllowanceTimeById(string id)
        {
            var record = await _context.TiffinAllowanceTimes.FindAsync(id);

            if (record == null)
                return NotFound();

            return record;
        }

        [HttpPost("TiffinAllowanceTime")]
        public async Task<IActionResult> CreateTiffinAllowanceTime([FromBody] TiffinAllowanceTime tiffinAllowanceTime)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _tat.InsertTiffinAllowanceTimeAsync(tiffinAllowanceTime);
            return Ok(new { message = "Tiffin allowance time inserted successfully" });
        }


        [HttpPut("TiffinAllowanceTime{id}")]
        public async Task<IActionResult> Update(string id, TiffinAllowanceTime record)
        {
            if (id != record.TiffinAllowanceID)
                return BadRequest();

            _context.Entry(record).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TiffinAllowanceTimes.Any(e => e.TiffinAllowanceID == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }


        [HttpDelete("TiffinAllowanceTime{id}")]
        public async Task<IActionResult> DeleteTiffinAllowanceTime(string id)
        {
            var record = await _context.TiffinAllowanceTimes.FindAsync(id);

            if (record == null)
                return NotFound();

            _context.TiffinAllowanceTimes.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //------------------------------------------NightAllowance-------------------------------------------------------

        [HttpGet("NightAllowance")]
        public async Task<ActionResult<IEnumerable<NightAllowance>>> GetAllNightAllowance()
        {
            return await _context.NightAllowances.ToListAsync();
        }


        [HttpGet("NightAllowance{id}")]
        public async Task<ActionResult<NightAllowance>> GetNightAllowanceById(string id)
        {
            var record = await _context.NightAllowances.FindAsync(id);
            if (record == null)
                return NotFound();
            return record;
        }


        [HttpPost("NightAllowance")]
        public async Task<IActionResult> Create([FromBody] NightAllowance model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _na.InsertNightAllowanceAsync(model);
            return Ok(new { message = "Night Allowance inserted successfully" });
        }


        [HttpPut("NightAllowance{id}")]
        public async Task<IActionResult> UpdateNightAllowance(string id, NightAllowance record)
        {
            if (id != record.NightAllowanceID)
                return BadRequest();

            _context.Entry(record).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.NightAllowances.Any(e => e.NightAllowanceID == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }


        [HttpDelete("NightAllowance{id}")]
        public async Task<IActionResult> DeleteNightAllowance(string id)
        {
            var record = await _context.NightAllowances.FindAsync(id);
            if (record == null)
                return NotFound();

            _context.NightAllowances.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        //------------------------------------------NightAllowanceTime-------------------------------------------------------

        [HttpGet("NightAllowanceTime")]
        public async Task<ActionResult<IEnumerable<NightAllowanceTime>>> GetAllNightAllowanceTime()
        {
            return await _context.NightAllowanceTimes.ToListAsync();
        }


        [HttpGet("NightAllowanceTime{id}")]
        public async Task<ActionResult<NightAllowanceTime>> GetNightAllowanceTimeById(string id)
        {
            var record = await _context.NightAllowanceTimes.FindAsync(id);
            if (record == null)
                return NotFound();
            return record;
        }


        [HttpPost("NightAllowanceTime")]
        public async Task<IActionResult> Create([FromBody] NightAllowanceTime model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _nat.InsertNightAllowanceTimeAsync(model);
            return Ok(new { message = "Night Allowance Time inserted successfully" });
        }


        [HttpPut("NightAllowanceTime{id}")]
        public async Task<IActionResult> UpdateNightAllowanceTime(string id, NightAllowanceTime record)
        {
            if (id != record.NightAllowanceTimeID)
                return BadRequest();

            _context.Entry(record).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.NightAllowanceTimes.Any(e => e.NightAllowanceTimeID == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }


        [HttpDelete("NightAllowanceTime{id}")]
        public async Task<IActionResult> DeleteNightAllowanceTime(string id)
        {
            var record = await _context.NightAllowanceTimes.FindAsync(id);
            if (record == null)
                return NotFound();

            _context.NightAllowanceTimes.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
