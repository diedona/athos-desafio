import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(
    private http: HttpClient,
  ) { }

  getAll(): Observable<Array<any>> {
    return this.http.get<Array<any>>(`${environment.apiUrl}/usuario`);
  }

  getByiId(id: number): Observable<any> {
    return this.http.get<Array<any>>(`${environment.apiUrl}/usuario/${id}`);
  }

  getSindicos(): Observable<Array<any>> {
    return this.http.get<Array<any>>(`${environment.apiUrl}/usuario/sindico`);
  }

  getZeladores(): Observable<Array<any>> {
    return this.http.get<Array<any>>(`${environment.apiUrl}/usuario/zelador`);
  }

  getMoradores(): Observable<Array<any>> {
    return this.http.get<Array<any>>(`${environment.apiUrl}/usuario/morador`);
  }

  save(usuario: any): Observable<void> {
    return this.http.post<void>(`${environment.apiUrl}/usuario/`, usuario);
  }

  update(usuario: any): Observable<void> {
    return this.http.put<void>(`${environment.apiUrl}/usuario/`, usuario);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${environment.apiUrl}/usuario/${id}`);
  }
}
