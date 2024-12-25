import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Employee, EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit {

  employees:Employee[]=[];
  showAddEmployeeForm = false;
  employeeForm!: FormGroup;
  isEditing = false;
  constructor(private employeeService: EmployeeService, private fb: FormBuilder, private router:Router) {}

  ngOnInit(): void {
    this.fetchEmployees();
    this.initializeForm();
  }

  fetchEmployees(): void {
    this.employeeService.getAllEmployees().subscribe((data) => {
      this.employees = data;
    });
  }

  initializeForm(): void {
    this.employeeForm = this.fb.group({
      employeeId: [null],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      emailId: ['', [Validators.required, Validators.email]],
      location: ['', Validators.required],
      dateOfBirth: [null, Validators.required],
    });
  }

  toggleAddEmployeeForm(): void {
    this.showAddEmployeeForm = !this.showAddEmployeeForm;
    this.isEditing = false;
    this.employeeForm.reset();
  }

  addOrUpdateEmployee(): void {
    if (this.isEditing) {
      console.log(this.employeeForm.value)
      // this.employeeService.updateEmployee(this.employeeForm.value).subscribe(() => {
      //   this.fetchEmployees();
      //   this.toggleAddEmployeeForm();
      // });
    } else {
      this.employeeService.createEmployee(this.employeeForm.value).subscribe(() => {
        this.fetchEmployees();
        this.toggleAddEmployeeForm();
      });
    }
  }

  populateForm(employee: any): void {
    this.employeeForm.patchValue({
      firstName: employee.firstName,
      lastName: employee.lastName,
      emailId: employee.emailId,
      location: employee.location,
      dateOfBirth: new Date(employee.dateOfBirth), // Convert to a Date object
    });
    this.isEditing = true;
    this.showAddEmployeeForm = true;
    console.log(employee.dateOfBirth);
    this.employeeForm.patchValue(employee);
  }

  deleteEmployee(id: number): void {
    this.employeeService.deleteEmployee(id).subscribe(() => {
      this.fetchEmployees();
    });
  }
  navigateToSalary(employeeId:number){
    this.router.navigate(['/salary-list', employeeId])
  }

  closeForm(){
      this.toggleAddEmployeeForm();
  }
}
