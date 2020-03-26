import { Component, Input } from '@angular/core';
import { PersonViewModel } from 'src/app/models/personViewModel';

@Component({
  selector: 'app-shared-list-person-component',
  templateUrl: './list-person.component.html'
})
export class ListPersonComponent {

  public listData: Array<PersonViewModel>;

  @Input()
  public set data(data: Array<PersonViewModel>) {
    this.listData = data;
  }
}
