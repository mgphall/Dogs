import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../shared/services/error-handler.service';
import { RepositoryService } from './../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Groups } from './../../_interfaces/groups.model';

@Component({
  selector: 'app-group-update',
  templateUrl: './group-update.component.html',
  styleUrls: ['./group-update.component.css']
})
export class GroupUpdateComponent implements OnInit {
  public errorMessage = '';
  public groups: Groups;
  public groupForm: FormGroup;


  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit() {
    this.groupForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(60)])
    });

    this.getGroupsById();
  }
  getGroupsById(): any {
    const groupId: string = this.activeRoute.snapshot.params['id'];

    const groupByIdUrl = `api/groups/${groupId}`;

    this.repository.getData(groupByIdUrl)
      .subscribe(res => {
        this.groups = res as Groups;
        this.groupForm.patchValue(this.groups);
      },

      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
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

  public redirectToGroupsList() {
    this.router.navigate(['/groups/list']);
  }

  public updateGroup(groupFormValue) {
    if (this.groupForm.valid) {
      this.executegroupUpdate(groupFormValue);
    }
  }

  private executegroupUpdate(groupFormValue) {

    this.groups.groupName = groupFormValue.name;

    const apiUrl = `api/groups/${this.groups.groupId}`;
    this.repository.update(apiUrl, this.groups)
      .subscribe(res => {
        $('#successModal').modal();
      },
      (error => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    );
  }

}
