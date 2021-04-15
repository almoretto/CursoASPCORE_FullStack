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

  // tslint:disable-next-line:variable-name
  // tslint:disable-next-line:variable-name
  _filterList = '';

  get filterList(): string
    { return this._filterList; }

  set filterList(value: string)
    {
      this._filterList = value;
      this.filteredEvents = this._filterList ? this.EventFilter(this.filterList) : this.events;
    }

  filteredEvents: any = [];
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
  EventFilter(filterBy: string): any
  {
    filterBy = filterBy.toLocaleLowerCase();
    return this.events.filter((events: { subject: { toLocaleLowerCase: () => number; }; }) => events.subject.toLocaleLowerCase() !== - 1);
    // this.events.filter(events => events.subject.toLocaleLowerCase() !== - 1);
    /* !== =  ! = = all together */
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
