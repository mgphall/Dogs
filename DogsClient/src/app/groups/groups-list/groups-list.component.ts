import { Component, OnInit } from '@angular/core';
import { RepositoryService } from './../../shared/services/repository.service';
import { Groups } from './../../_interfaces/groups.model';
import { ErrorHandlerService } from './../../shared/services/error-handler.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-groups-list',
  templateUrl: './groups-list.component.html',
  styleUrls: ['./groups-list.component.css']
})
export class GroupsListComponent implements OnInit {
  public groups: Groups[];
  public errorMessage = '';

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router ) { }

  ngOnInit() {
    this.getAllGroups();
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

 public getGroupsDetails(id) {
    const detailsUrl = `/groups/details/${id}`;
    this.router.navigate([detailsUrl]);
  }

  public redirectToUpdatePage(id) {
      const updateUrl  = `/groups/update/${id}`;
      this.router.navigate([updateUrl]);
  }

  public redirectToDeletePage(id) {
    const deleteUrl = `/groups/delete/${id}`;
    this.router.navigate([deleteUrl]);
  }
}
