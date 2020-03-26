import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Person } from 'src/app/models/person';
import { PersonViewModel } from 'src/app/models/personViewModel';
import { Observable } from 'rxjs';
import { Group } from 'src/app/models/group';

@Injectable()
export class PersonDataService {
    constructor(private httpClient: HttpClient, @Inject('BASE_URL') private apiUrl: string) 
    { }

    httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }
    
    createPerson(person: Person): Observable<number> {
        return this.httpClient.post<number>(this.apiUrl + "api/data/Person", JSON.stringify(person), this.httpOptions);
    }

    getPersons(): Observable<Array<PersonViewModel>> {
        return this.httpClient.get<Array<PersonViewModel>>(this.apiUrl + "api/data/Person");
    }

    getPersonsByFullnameOrGroupname(query: string): Observable<Array<PersonViewModel>> {
      return this.httpClient.get<Array<PersonViewModel>>(this.apiUrl + "api/data/Person/getPersonByNameOrGroupName?query=" + query);
    }

    getGroups(): Observable<Array<Group>> {
      return this.httpClient.get<Array<Group>>(this.apiUrl + "api/data/group");

  }
}
