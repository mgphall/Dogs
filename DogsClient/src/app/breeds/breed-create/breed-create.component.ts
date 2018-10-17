import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CreateBreed } from '../../_interfaces/createBreed.model';
import { ErrorHandlerService } from './../../shared/services/error-handler.service';
import { RepositoryService } from './../../shared/services/repository.service';
import { Router } from '@angular/router';
import { Groups } from './../../_interfaces/groups.model';

@Component({
  selector: 'app-breed-create',
  templateUrl: './breed-create.component.html',
  styleUrls: ['./breed-create.component.css']
})

export class BreedCreateComponent implements OnInit {
  public errorMessage = '';
  public groups: Groups[];
  public breedForm: FormGroup;

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router) { }

  ngOnInit() {
    this.getAllGroups();


    this.breedForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      groupid : new FormControl('', [Validators.required])
    });

  }

  public validateControl(controlName: string) {
    if (this.breedForm.controls[controlName].invalid && this.breedForm.controls[controlName].touched) {
      return true;
    }

    return false;
  }

  public hasError(controlName: string, errorName: string) {
    if (this.breedForm.controls[controlName].hasError(errorName)) {
      return true;
    }

    return false;
  }

  public createBreed(breedFormValue) {
    if (this.breedForm.valid) {
      this.executeGroupCreation(breedFormValue);
    }
  }

  private executeGroupCreation(breedFormValue) {
    const breed: CreateBreed = {
      Breed : breedFormValue.name,
       groupId : breedFormValue.groupid
    };
    const apiUrl = 'api/breeds';
    this.repository.create(apiUrl, breed)
      .subscribe(res => {
        $('#successModal').modal();
      },
      (error => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      }));
    }

    public getAllGroups() {
      const apiAddress = 'api/groups';
      this.repository.getData(apiAddress)
      .subscribe(res => {
        this.groups = res as Groups[];
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      });
    }

  public redirectToBreedsList() {
    this.router.navigate(['/breeds/list']);
  }

}
