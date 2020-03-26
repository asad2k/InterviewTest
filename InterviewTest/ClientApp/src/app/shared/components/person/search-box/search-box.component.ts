import { Component } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { PersonViewModel } from 'src/app/models/personViewModel';
import { Router } from '@angular/router';
import { SharedDataService } from 'src/app/services/sharedDataService';
import { PersonDataService } from 'src/app/person/services/person.data.service';

@Component({
  selector: 'app-shared-search-box-component',
  templateUrl: './search-box.component.html'
})
export class SearchBoxComponent {
  public form: FormGroup;
  public listData: Array<PersonViewModel> = null;
  private alreadyNavigated = false;

  constructor(formBuilder: FormBuilder,
    private router: Router, 
    private sharedDataService: SharedDataService, 
    private personDataService: PersonDataService) {
    this.form = formBuilder.group({
      searchBox: new FormControl('', [Validators.required])
    });
  }

  public performSearch(): void {
    const query = this.form.controls.searchBox.value;

    if (!query) {
      this.form.controls.searchBox.markAsTouched();
      return;
    }

    this.personDataService.getPersonsByFullnameOrGroupname(query).subscribe(response => {
      this.sharedDataService.personSearchResult = response;

      this.navigateToSearchPage();
    });
  }

  private navigateToSearchPage() : void {
    if (!this.alreadyNavigated) {
      this.router.navigate(['/search']);
      this.alreadyNavigated = true;
    }
  }
}
