import { Component} from '@angular/core'; 
import { Router, NavigationStart, RoutesRecognized, ActivatedRoute } from '@angular/router';
import { FormBuilder, Validators, ReactiveFormsModule, FormGroup } from '@angular/forms';
import { filter } from 'rxjs/operators';
import { ContactService } from '../../../../@core/services/contact.service';

@Component({
    selector: 'site-contact',
    templateUrl: './contact.component.html',
})
export class ContactComponent {
  public contactForm: FormGroup;
  ContactDetails: any = {};
  DBResponce: any = {};

  constructor(private contactService: ContactService, private formBuilder: FormBuilder, private router: Router) { }

    ngOnInit() {
      this.contactForm = this.formBuilder.group({
        Name: ['', [Validators.nullValidator]],
        Email: ['', [Validators.email]],
        Message: ['', [Validators.required]],

      }); 
    }
    
  SavContact() {

    this.ContactDetails.Name = this.contactForm.value.Name;
    this.ContactDetails.Email = this.contactForm.value.Email;
    this.ContactDetails.Message = this.contactForm.value.Message;

    this.contactService.SaveComment(this.ContactDetails).subscribe(res => {
      this.DBResponce = res;
      this.contactForm.reset();
      if (this.DBResponce != null && this.DBResponce.responseResult) {
      }
    });
  }
}
