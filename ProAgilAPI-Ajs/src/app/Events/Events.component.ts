import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'app-Events',
  templateUrl: './Events.component.html',
  styleUrls: ['./Events.component.css']
})

export class EventsComponent implements OnInit
{

  constructor(private http: HttpClient) { }

  events: any;

  // tslint:disable-next-line:typedef
  ngOnInit()
  {
    this.GetEvents();
  }


  GetEvents(): any
  {
    this.http.get('http://localhost:5000/api/values').subscribe(response =>
      {
        this.events = response;
      }, error =>
      {
        console.log(error);
      }
    );
  }
}
