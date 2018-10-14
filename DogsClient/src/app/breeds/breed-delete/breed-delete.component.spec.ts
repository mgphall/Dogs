import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BreedDeleteComponent } from './breed-delete.component';

describe('BreedDeleteComponent', () => {
  let component: BreedDeleteComponent;
  let fixture: ComponentFixture<BreedDeleteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BreedDeleteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BreedDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
