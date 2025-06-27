namespace HRIS_R62.DTOforSp
{
    public class EmployeeAttendanceDto
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string UnitName { get; set; }
        public string DivisionName { get; set; }
        public string DepartmentName { get; set; }
        public string SectionName { get; set; }
        public string LineName { get; set; }

        public DateTime? RecordDate { get; set; }

        public TimeSpan? InTime { get; set; }   // <-- changed
        public TimeSpan? OutTime { get; set; }  // <-- changed

        public string PresentStatus { get; set; }

    }


}
