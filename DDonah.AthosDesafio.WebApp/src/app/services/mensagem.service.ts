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

  getByiId(id: number): Observable<any> {
    return this.http.get<Array<any>>(`${environment.apiUrl}/mensagem/${id}`);
  }

  save(mensagem: any): Observable<void> {
    return this.http.post<void>(`${environment.apiUrl}/mensagem/`, mensagem);
  }
}
