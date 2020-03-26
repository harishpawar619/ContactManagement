import { Component, OnInit } from '@angular/core';
import { ContactServiceService } from '../contact-service.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {

  searchInput: string = '';
  addEditStr = 'Add';
  contactsData: any = [];
  ContactDetailForm: FormGroup;
    submitted = false;
  contactObj: any = this.getNewObj();
  constructor(private _service: ContactServiceService,private formBuilder: FormBuilder) { }

  ngOnInit() {
     this.getAllData();
     this.ContactDetailForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required]],
      phoneNumber: ['', [Validators.required]],
     
  
  });
  }

  getNewObj(){
    return {      
        contactId: 0,
        firstName: '',
        lastName: '',
        email: '',
        phoneNumber: ''      
    }
  }


  saveCall(saveObject) {
  //   if (this.ContactDetailForm.invalid) {
  //     return false;
  // }
    if(this.addEditStr === 'Add') {
      this._service.addContact(saveObject).subscribe(res => {
        if (res) {
          this.getAllData();
        }
      });
    } else {
      this._service.updateContact(saveObject).subscribe(res => {
        if (res) {
          this.getAllData();
        }
      });
    }
    
  }
  
  onDeleteClick(updatedObj) {
    this._service.deleteContact(updatedObj).subscribe(res => {
      this.getAllData();
    });
  }
  onAddclick() {
    this.contactObj = this.getNewObj();
    this.addEditStr = 'Add';
  }
  onUpdateClick(updatedObj) {
    this.contactObj = updatedObj;
    this.addEditStr = 'Edit';
  }
  getAllData() {
    this._service.getAllContacts().subscribe(res => {
      this.contactsData = res
    });
   

    //   this._serviceTransporter.getAllVendors().subscribe(res => {
    //     this.vendorData = res
    //   });
    //   this._serviceTransporter.getAllMaterials().subscribe(res => {
    //     this.materialsData = res
    //   });

  }


}
