import { Component, OnInit } from '@angular/core';
import { Event } from '@angular/router';
import { EventService } from '../services/Event.service'; // Injection Dependency for the service layer

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'app-Events',
  templateUrl: './Events.component.html',
  styleUrls: ['./Events.component.css']
})

export class EventsComponent implements OnInit
{

  constructor(private eventService: EventService) { } // Constructor with dependency injection from the service layer

  eventsView: Event[]; /* this line declares a variable and atributes a null value of Array
                      * to it using the [] */
  filteredEvents: Event[];
  // tslint:disable-next-line:variable-name
  _filterList = '';

  get filterList(): string
    { return this._filterList; }

  set filterList(value: string)
    {
      this._filterList = value;
      this.filteredEvents = this._filterList ? this.EventFilter(this.filterList) : this.eventsView;
    }

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
  EventFilter(filterBy: string): Event[]
  {
    filterBy = filterBy.toLocaleLowerCase();
    return this.eventsView.filter((events: { subject: string; }) => events.subject.toLocaleLowerCase().indexOf(filterBy) !== - 1);
    // this.events.filter(events => events.subject.toLocaleLowerCase() !== - 1);
    /* !== =  ! = = all together */
  }
  GetEvents(): Event[]
  {
    // tslint:disable-next-line: deprecation
    this.eventService.getEvents().subscribe((events: Event[]) =>
      {
        this.eventsView = events;
        this.EventFilter = this.eventsView;
        console.log(events);
      }, error =>
      {
        console.log(error);
      }
    );
  }
}
