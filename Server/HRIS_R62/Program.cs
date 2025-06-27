
using HRIS_R62.Models;
using HRIS_R62.RepoForSp;
using Microsoft.EntityFrameworkCore;

namespace HRIS_R62
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("appCon")));

            //added by nokib
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            

            //Mofizul RiPO
            builder.Services.AddScoped<ISalaryGradeRepository, SalaryGradeRepository>();
            builder.Services.AddScoped<ISalaryDeductionRepository, SalaryDeductionRepository>();
            builder.Services.AddScoped<ISalaryEntryRepository, SalaryEntryRepository>();
            builder.Services.AddScoped<ISalaryProcessRepository, SalaryProcessRepository>();
            builder.Services.AddScoped<ISalaryRecordRepository, SalaryRecordRepository>();
            builder.Services.AddScoped<IBonusRecordRepository, BonusRecordRepository>();
            builder.Services.AddScoped<IFestivalBonusRepository, FestivalBonusRepository>();
            builder.Services.AddScoped<IFoodChargeRepository, FoodChargeRepository>();
            builder.Services.AddScoped<ITiffinAllowanceRateRepository, TiffinAllowanceRateRepository>();
            builder.Services.AddScoped<ITiffinAllowanceTimeRepository, TiffinAllowanceTimeRepository>();
            builder.Services.AddScoped<INightAllowanceTimeRepository, NightAllowanceTimeRepository>();
            builder.Services.AddScoped<INightAllowanceRepository, NightAllowanceRepository>();

            var app = builder.Build();

            //added by nokib // Configure the HTTP request pipeline.
            app.UseCors("AllowAll");

            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
        // In a migration file


    }
}
