import { Component } from '@angular/core';
import { PersonViewModel } from 'src/app/models/personViewModel';
import { SharedDataService } from 'src/app/services/sharedDataService';

@Component({
  selector: 'app-search-person-component',
  templateUrl: './search-person.component.html'
})
export class SearchPersonComponent {
  constructor(private sharedDataService: SharedDataService) {
  }

  public get listData(): Array<PersonViewModel> {
    return this.sharedDataService.personSearchResult;
  }
}
