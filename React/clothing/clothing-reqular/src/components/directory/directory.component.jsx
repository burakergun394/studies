import "./directory.styles.scss";
import CategoryItem from "../category-item/category-item.component";

const Directory = (props) => {
  const { categories } = props;

  return (
    <div className="directory-container">
      {categories.map((category) => {
        return <CategoryItem key={category.id} category={category} />;
      })}
    </div>
  );
};

export default Directory;
