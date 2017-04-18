import { ConstructionFrontEndPage } from './app.po';

describe('construction-front-end App', () => {
  let page: ConstructionFrontEndPage;

  beforeEach(() => {
    page = new ConstructionFrontEndPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
