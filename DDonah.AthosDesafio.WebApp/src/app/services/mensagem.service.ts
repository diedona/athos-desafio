import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MensagemService {

  constructor(
    private http: HttpClient,
  ) { }

  getAll(): Observable<Array<any>> {
    return this.http.get<Array<any>>(`${environment.apiUrl}/mensagem`);
  }

  getAssuntos(): Observable<Array<any>> {
    return this.http.get<Array<any>>(`${environment.apiUrl}/mensagem/assunto`);
  }

  getById(id: number): Observable<any> {
    return this.http.get<Array<any>>(`${environment.apiUrl}/mensagem/${id}`);
  }

  save(mensagem: any): Observable<any> {
    return this.http.post<any>(`${environment.apiUrl}/mensagem/`, mensagem);
  }
}
