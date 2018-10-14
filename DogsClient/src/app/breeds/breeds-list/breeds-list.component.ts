import { Component, OnInit } from '@angular/core';
import { Breeds } from 'src/app/_interfaces/breeds.model';
import { RepositoryService } from './../../shared/services/repository.service';
import { ErrorHandlerService } from './../../shared/services/error-handler.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-breeds-list',
  templateUrl: './breeds-list.component.html',
  styleUrls: ['./breeds-list.component.css']
})

export class BreedsListComponent implements OnInit {
  public breeds: Breeds[];
  public errorMessage = '';

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
     private activeRoute: ActivatedRoute) { }

  ngOnInit() {

    let breedId = '';

    if (this.activeRoute.snapshot.params['id']) {
      breedId  = `${this.activeRoute.snapshot.params['id']}/group`;
    }

    this.getBreeds(breedId);
  }

  public getBreeds(breedId = '') {

    const id = breedId;
    const apiAddress = `api/breeds/${id}`;
    this.repository.getData(apiAddress)
    .subscribe(res => {
      this.breeds = res as Breeds[];
    },
    (error) => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    });
  }

  public redirectToUpdatePage(id) {
    const updateUrl  = `/breeds/update/${id}`;
    this.router.navigate([updateUrl]);
}

public redirectToDeletePage(id) {
  const updateUrl  = `/breeds/delete/${id}`;
  this.router.navigate([updateUrl]);
}

}
