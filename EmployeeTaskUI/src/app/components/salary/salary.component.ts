import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Salary, SalaryService } from 'src/app/services/salary.service';

@Component({
  selector: 'app-salary',
  templateUrl: './salary.component.html',
  styleUrls: ['./salary.component.scss']
})

export class SalaryComponent implements OnInit {
  salaries:Salary[] = [];
  showAddSalaryForm = false;
  salaryForm!: FormGroup;
  isEditing = false;
  employeeId :number= 0;

  constructor(private salaryService: SalaryService, private fb: FormBuilder, private route:ActivatedRoute) {}

  ngOnInit(): void {
      this.route.paramMap.subscribe(params => {
      this.employeeId = +params.get('employeeId')!; // Extract the employeeId from the route
    });
    this.fetchSalaries();
    this.initializeForm();
  }

  fetchSalaries(): void {
    this.salaryService.getSalariesByEmployeeId(this.employeeId).subscribe((data) => {
      this.salaries = data;
    });
  }

  initializeForm(): void {
    this.salaryForm = this.fb.group({
      id: [null],
      amount: ['', Validators.required],
      payDate: ['', Validators.required],
    });
  }

  toggleAddSalaryForm(): void {
    this.showAddSalaryForm = !this.showAddSalaryForm;
    this.isEditing = false;
    this.salaryForm.reset();
  }

  addOrUpdateSalary(): void {
    if (this.isEditing) {
      this.salaryService.updateSalary(this.salaryForm.value).subscribe(() => {
        this.fetchSalaries();
        this.toggleAddSalaryForm();
      });
    } else {
      this.salaryService.createSalary(this.salaryForm.value).subscribe(() => {
        this.fetchSalaries();
        this.toggleAddSalaryForm();
      });
    }
  }

  populateForm(salary: any): void {
    this.isEditing = true;
    this.showAddSalaryForm = true;
    this.salaryForm.patchValue(salary);
  }

  deleteSalary(id: number): void {
    this.salaryService.deleteSalary(id).subscribe(() => {
      this.fetchSalaries();
    });
  }
}
