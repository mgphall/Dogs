import { Component, OnInit } from '@angular/core';
import { ErrorHandlerService } from './../../shared/services/error-handler.service';
import { RepositoryService } from './../../shared/services/repository.service';
import { Groups } from './../../_interfaces/groups.model';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-group-delete',
  templateUrl: './group-delete.component.html',
  styleUrls: ['./group-delete.component.css']
})
export class GroupDeleteComponent implements OnInit {

  public errorMessage: string = '';
  public group: Groups;

constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
  private activeRoute: ActivatedRoute) { }


ngOnInit() {
  this.getGruopById();
}
 private getGruopById(): any {
    const groupId: string  = this.activeRoute.snapshot.params['id'];
    const groupByIdUrl = `api/groups/${groupId}`;

    this.repository.getData(groupByIdUrl)
      .subscribe(res => {
        this.group = res as Groups;
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      });
  }

  public deleteGroup() {
    const deleteUrl: string = `api/groups/${this.group.groupdId}`;
    this.repository.delete(deleteUrl)
      .subscribe(res => {
        $('#successModal').modal();
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      });
  }

  public redirectToGroupList() {
    this.router.navigate(['/groups/list']);
  }

}
