import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'app-Events',
  templateUrl: './Events.component.html',
  styleUrls: ['./Events.component.css']
})

export class EventsComponent implements OnInit
{

  constructor(private http: HttpClient) { }

  events: any = []; /* this line declares a variable and atributes a null value of Array to it using the [] */
  _filterType: string;

  get filterType(): string
    { return this._filterType; }

  set filterType(value: string)
    { this._filterType = value; }

  /*properties for using on URL*/
  imgWidth = 70;
  imgMargin = 2;
  showImg = false;

  // tslint:disable-next-line:typedef
  ngOnInit()
  {
    this.GetEvents();
  }

  ImgAlternate(): void {
    this.showImg = !this.showImg;
  }

  GetEvents(): any
  {
    // tslint:disable-next-line: deprecation
    this.http.get('http://localhost:8080/api/values').subscribe(response =>
      {
        this.events = response;
      }, error =>
      {
        console.log(error);
      }
    );
  }
}
