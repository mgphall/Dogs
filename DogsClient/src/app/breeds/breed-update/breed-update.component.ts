import { Breeds } from 'src/app/_interfaces/breeds.model';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../shared/services/error-handler.service';
import { RepositoryService } from './../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Groups } from './../../_interfaces/groups.model';

@Component({
  selector: 'app-breed-update',
  templateUrl: './breed-update.component.html',
  styleUrls: ['./breed-update.component.css']
})
export class BreedUpdateComponent implements OnInit {
  public errorMessage = '';
  public breed: Breeds;
  public breedForm: FormGroup;
  public groups: Groups[];
  public nrSelect: Groups;

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }


  ngOnInit() {
    this.breedForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(60)])
    });

    this.getAllGroups();
    this.getBreedById();

    this.nrSelect = this.filterSelectedGroup();

    }
  getBreedById(): any {
    const breedId: string = this.activeRoute.snapshot.params['id'];

    const groupByIdUrl = `api/breeds/${breedId}`;

    this.repository.getData(groupByIdUrl)
      .subscribe(res => {
        this.breed = res as Breeds;
        this.breedForm.patchValue(this.breed);
      },

      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
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

  get filterSelectedGroup() {
    return this.groups.filter( x => x.groupdId === this.breed.groupdId).some[1];
  }

  public redirectToBreedList() {
    this.router.navigate(['/breeds/list']);
  }

  public updateBreed(breedFormValue) {
    if (this.breedForm.valid) {
      this.executeBreedUpdate(breedFormValue);
    }
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

  private executeBreedUpdate(breedFormValue) {

    this.breed.breed = breedFormValue.name;

    const apiUrl = `api/breeds/${this.breed.id}`;
    this.repository.update(apiUrl, this.breed)
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
