import { Component, OnInit } from '@angular/core';
import { Groups } from './../../_interfaces/groups.model';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../shared/services/repository.service';
import { ErrorHandlerService } from './../../shared/services/error-handler.service';


@Component({
  selector: 'app-groups-details',
  templateUrl: './groups-details.component.html',
  styleUrls: ['./groups-details.component.css']
})
export class GroupsDetailsComponent implements OnInit {
  public group: Groups;
  public errorMessage = '';

  constructor(private repository: RepositoryService, private router: Router,
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

    ngOnInit() {
      this.getGroupsDetails();
    }

    getGroupsDetails() {
      const id: string = this.activeRoute.snapshot.params['id'];
      const apiUrl = `api/groups/${id}/breeds`;

      this.repository.getData(apiUrl)
      .subscribe(res => {
        this.group = res  as Groups;
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      });
    }

    public redirectToDetailsPage(id) {
      const updateUrl  = `breeds/list/${id}`;
      this.router.navigate([updateUrl]);
    }
}
