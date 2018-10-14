import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BreedUpdateComponent } from './breed-update.component';

describe('BreedUpdateComponent', () => {
  let component: BreedUpdateComponent;
  let fixture: ComponentFixture<BreedUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BreedUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BreedUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
