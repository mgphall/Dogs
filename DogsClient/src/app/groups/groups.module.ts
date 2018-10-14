import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SharedModule } from './../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';

import { GroupsListComponent } from './groups-list/groups-list.component';
import { GroupsDetailsComponent } from './groups-details/groups-details.component';
import { GroupCreateComponent } from './group-create/group-create.component';
import { GroupUpdateComponent } from './group-update/group-update.component';
import { GroupDeleteComponent } from './group-delete/group-delete.component';

@NgModule({
    imports: [
      CommonModule,
      SharedModule,
      ReactiveFormsModule,
      RouterModule.forChild([
        { path: 'list', component: GroupsListComponent },
        { path: 'details/:id', component: GroupsDetailsComponent },
        { path: 'create', component: GroupCreateComponent },
        { path: 'update/:id', component: GroupUpdateComponent},
        { path: 'delete/:id', component: GroupDeleteComponent }
      ])
    ],
    declarations: [
        GroupsListComponent,
        GroupsDetailsComponent,
        GroupCreateComponent,
        GroupUpdateComponent,
        GroupDeleteComponent
    ]
  })

export class GroupsModule { }
