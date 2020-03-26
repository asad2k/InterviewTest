import { Component, OnInit } from '@angular/core';
import { PersonDataService } from '../person/services/person.data.service';
import { PersonViewModel } from '../models/personViewModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  public persons: Array<PersonViewModel>;

  constructor(private personDataService: PersonDataService) {
  }

  ngOnInit(): void {
    this.personDataService.getPersons()
    .subscribe(response => {
      this.persons = response;
    }, (error) => {
    });
  }
}
