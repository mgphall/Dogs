import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CreateGroup } from '../../_interfaces/createGroup.model';
import { ErrorHandlerService } from './../../shared/services/error-handler.service';
import { RepositoryService } from './../../shared/services/repository.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-group-create',
  templateUrl: './group-create.component.html',
  styleUrls: ['./group-create.component.css']
})
export class GroupCreateComponent implements OnInit {

  public errorMessage = '';

  public groupForm: FormGroup;

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router) { }

  ngOnInit() {
    this.groupForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(60)]),

    });
  }

  public validateControl(controlName: string) {
    if (this.groupForm.controls[controlName].invalid && this.groupForm.controls[controlName].touched) {
      return true;
    }

    return false;
  }
  public hasError(controlName: string, errorName: string) {
    if (this.groupForm.controls[controlName].hasError(errorName)) {
      return true;
    }

    return false;
  }

  public createGroup(groupFormValue) {
    if (this.groupForm.valid) {
      this.executeGroupCreation(groupFormValue);
    }
  }

  private executeGroupCreation(groupFormValue) {
    const group: CreateGroup = {
     groupName: groupFormValue.name

    };
    const apiUrl = 'api/groups';
    this.repository.create(apiUrl, group)
      .subscribe(res => {
        $('#successModal').modal();
      },
      (error => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      }));
    }


  public redirectToGroupsList() {
    this.router.navigate(['/groups/list']);
  }
}
