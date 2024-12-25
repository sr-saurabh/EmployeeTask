import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './components/employee/employee.component';
import { SalaryComponent } from './components/salary/salary.component';

const routes: Routes = [
  {path:"employee", component:EmployeeComponent},
  {path:"", redirectTo:'employee', pathMatch:'full'},
  { path: 'salary-list/:employeeId', component: SalaryComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
