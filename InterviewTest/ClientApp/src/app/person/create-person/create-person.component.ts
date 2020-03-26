import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { PersonDataService } from '../services/person.data.service';
import { Group } from 'src/app/models/group';
import { Person } from 'src/app/models/person';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-person-component',
  templateUrl: './create-person.component.html'
})
export class CreatePersonComponent implements OnInit {
  public form: FormGroup;
  public groups = new Array<Group>();

  constructor(private formBuilder: FormBuilder, private personDataService: PersonDataService, private router: Router) {
    this.form = this.formBuilder.group({
      fullName: new FormControl('', [Validators.required]),
      groupId: new FormControl('', [Validators.required])
    });
  }

  public add(person: Person) {

    if (!this.form.valid) {
      this.form.controls.fullName.markAsTouched();
      this.form.controls.groupId.markAsTouched();
      return;
    }

    this.personDataService.createPerson(person).subscribe(response => {
      alert("succesfully added!");

      this.router.navigate(['']);
    }, (error) => {
      alert("Oops something went wrong error");
      });
  }

  ngOnInit(): void {
    this.personDataService.getGroups().subscribe(response => {
      this.groups = response;
    });
  }
}
