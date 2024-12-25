import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Salary {
  salaryId: number;
  employeeId: number;
  itemType:string;
  name:string;
  value: number;
}

@Injectable({
  providedIn: 'root'
})
export class SalaryService {
  private apiUrl = `https://localhost:7157/api/salary`;  // Adjust the base URL to your API

  constructor(private http: HttpClient) { }

  getSalariesByEmployeeId(employeeId: number): Observable<Salary[]> {
    return this.http.get<Salary[]>(`${this.apiUrl}/employee/${employeeId}`);
  }

  createSalary(salary: Salary): Observable<Salary> {
    return this.http.post<Salary>(this.apiUrl, salary);
  }

  updateSalary(salary: Salary): Observable<Salary> {
    return this.http.put<Salary>(`${this.apiUrl}`, salary);
  }

  deleteSalary(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
