import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from './../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ContactServiceService {
  constructor(private http: HttpClient) { }

  getAllContacts() {
    return this.http.get<any>(environment.BaseUrl+`GetContacts`
      , { headers: { 'content-type': 'application/x-www-form-urlencoded', 'Access-control-allow-origin': '*', method: 'JSONP' } })
      .pipe(map(customers => {
        // login successful if there's a jwt token in the response

        return customers;
      }));
  }

  addContact(contact) {
    return this.http.post(environment.BaseUrl+`AddContact`, contact)
      .pipe(map(contact => {
        return contact;
      }));
  }
  updateContact(contact) {
    return this.http.put(environment.BaseUrl+`UpdateContact`, contact)
      .pipe(map(contact => {
    return contact;
      }));
  }
  deleteContact(contact) {
    return this.http.delete(environment.BaseUrl+`DeleteContact?contactId=`+ contact.contactId)
      .pipe(map(contact => {
         return contact;
      }));
  }

}
