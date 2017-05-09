import { B2kConstructionAngularPage } from './app.po';

describe('b2k-construction-angular App', () => {
  let page: B2kConstructionAngularPage;

  beforeEach(() => {
    page = new B2kConstructionAngularPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
