import { Component } from '@angular/core';
import { Router, NavigationStart, RoutesRecognized, ActivatedRoute } from '@angular/router';
import { FormBuilder, Validators, ReactiveFormsModule, FormGroup  } from '@angular/forms';
import { filter } from 'rxjs/operators';
import { CommentService } from '../../../../@core/services/comment.service';

@Component({
    selector: 'site-comment',
    templateUrl: './comment.component.html',
})
export class CommentComponent {
    public commentForm: FormGroup;
    CommentDetails: any = {};
    DBResponce: any = {};
    constructor(private commentService: CommentService, private formBuilder: FormBuilder, private router: Router) { }

    ngOnInit() { 
        this.commentForm = this.formBuilder.group({
            Name: ['', [Validators.nullValidator]],
            Email: ['', [Validators.email]],
            Subject: ['', [Validators.required]],
            Message: ['', [Validators.required]],

        });
    }
    SavComment() {

        this.CommentDetails.Name = this.commentForm.value.Name;
        this.CommentDetails.Email = this.commentForm.value.Email;
        this.CommentDetails.Subject = this.commentForm.value.Subject;
        this.CommentDetails.Message = this.commentForm.value.Message;

        this.commentService.SaveComment(this.CommentDetails).subscribe(res => {
            this.DBResponce = res;
            this.commentForm.reset();
            if (this.DBResponce != null && this.DBResponce.responseResult) {
                //this.toastrService.success(this.DBResponce.message);
            }
            //else if (this.DBResponce != null)
               // this.toastrService.error(this.DBResponce.message);

        });
    }
}
