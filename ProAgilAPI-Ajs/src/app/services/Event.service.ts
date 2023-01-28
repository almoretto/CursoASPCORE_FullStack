import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventService {
  baseUrl = 'http://localhost:8080/api/event';

  constructor(private http: HttpClient) { }

  // tslint:disable-next-line:typedef
  getEvents(): Observable<Event[]>{
    return this.http.get<Event[]>(this.baseUrl);
  }
  getEventBySubject(subject: string): Observable<Event[]>{
    return this.http.get<Event[]>(`${this.baseUrl}/getBySubject/${subject}`);
  }
  getEventById(id: number): Observable<Event>{
    return this.http.get<Event>(`${this.baseUrl}/getById/${id}`);
  }

}
