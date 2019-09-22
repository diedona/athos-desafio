import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from './../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CondominioService {

  constructor(
    private http: HttpClient,
  ) { }

  getAll(): Observable<Array<any>> {
    return this.http.get<Array<any>>(`${environment.apiUrl}/condominio`);
  }

  getById(id: number): Observable<any> {
    return this.http.get<any>(`${environment.apiUrl}/condominio/${id}`);
  }

  save(condominio: any): Observable<void> {
    return this.http.post<any>(`${environment.apiUrl}/condominio/`, condominio);
  }

  update(condominio: any): Observable<void> {
    return this.http.put<any>(`${environment.apiUrl}/condominio/`, condominio);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<any>(`${environment.apiUrl}/condominio/${id}`);
  }
}
