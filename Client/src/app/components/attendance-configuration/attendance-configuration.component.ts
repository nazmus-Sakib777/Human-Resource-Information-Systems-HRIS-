
import { Component, OnInit } from '@angular/core';
import { AttendanceConfiguration } from '../../models/attendance-configuration';
import { AttendanceConfigurationService } from '../../services/attendance-configuration.service';

@Component({
  selector: 'app-attendance-configuration',
  templateUrl: './attendance-configuration.component.html',
  styleUrls: ['./attendance-configuration.component.css']
})
export class AttendanceConfigurationComponent implements OnInit {
  configs: AttendanceConfiguration[] = [];
  model: AttendanceConfiguration = new AttendanceConfiguration();

  constructor(private service: AttendanceConfigurationService) { }

  ngOnInit() {
    this.load();
  }

  load() {
    this.service.getAll().subscribe(data => this.configs = data);
  }

  save() {
    if (!this.model.attendanceConfigurationID.trim()) {
      alert("ID must be provided");
      return;
    }

    const existing = this.configs.find(x => x.attendanceConfigurationID === this.model.attendanceConfigurationID);

    if (!existing) {
      // Create
      this.service.create(this.model).subscribe(() => {
        this.load();
        this.reset();
      });
    } else {
      // Update
      this.service.update(this.model.attendanceConfigurationID, this.model).subscribe(() => {
        this.load();
        this.reset();
      });
    }
  }

  edit(config: AttendanceConfiguration) {
    this.model = { ...config };
  }

  delete(id: string) {
    if (confirm('Are you sure to delete?')) {
      this.service.delete(id).subscribe(() => {
        this.load();
      });
    }
  }

  reset() {
    this.model = new AttendanceConfiguration();
  }

  isUpdate(): boolean {
    return this.model.attendanceConfigurationID.trim() !== '' &&
      this.configs.some(x => x.attendanceConfigurationID === this.model.attendanceConfigurationID);
  }
}


//import { Component } from '@angular/core';

//@Component({
//  selector: 'app-attendance-configuration',
//  templateUrl: './attendance-configuration.component.html',
//  styleUrls: ['./attendance-configuration.component.css']
//})
//export class AttendanceConfigurationComponent {

//}



