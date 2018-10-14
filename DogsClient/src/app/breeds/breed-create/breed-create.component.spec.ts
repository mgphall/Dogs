import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BreedCreateComponent } from './breed-create.component';

describe('BreedCreateComponent', () => {
  let component: BreedCreateComponent;
  let fixture: ComponentFixture<BreedCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BreedCreateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BreedCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
