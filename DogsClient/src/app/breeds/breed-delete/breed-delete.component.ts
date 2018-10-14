import { Breeds } from 'src/app/_interfaces/breeds.model';
import { Component, OnInit } from '@angular/core';
import { ErrorHandlerService } from './../../shared/services/error-handler.service';
import { RepositoryService } from './../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-breed-delete',
  templateUrl: './breed-delete.component.html',
  styleUrls: ['./breed-delete.component.css']
})
export class BreedDeleteComponent implements OnInit {

  public errorMessage = '';
  public breed: Breeds;

constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
  private activeRoute: ActivatedRoute) { }

  ngOnInit() {
    this.getBreedById();
  }

  private getBreedById(): any {
    const id: string  = this.activeRoute.snapshot.params['id'];
    const breedByIdUrl = `api/breeds/${id}`;

    this.repository.getData(breedByIdUrl)
      .subscribe(res => {
        this.breed = res as Breeds;
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      });
  }

  public deleteBreed(id) {
    const deleteUrl = `api/breeds/${id}`;
    this.repository.delete(deleteUrl)
      .subscribe(res => {
        $('#successModal').modal();
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      });
  }

  public redirectToBreedList() {
    this.router.navigate(['/breeds/list']);
  }

}
