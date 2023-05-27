import { useQuery} from 'react-query';
import RecipeCard from './RecipeCard';
import { Container, Col, Row } from 'reactstrap';
import { Cloudinary } from "@cloudinary/url-gen";

const retrieveRecipes = async () => {
    const response = await fetch('home');
    return await response.json();
}

export default function Home() {
    const cld = new Cloudinary({
        cloud: {
            cloudName: 'drsnwqblv'
        }
    });

    const { isLoading, data, error } = useQuery("recipes", retrieveRecipes);
    var recipes = [];

    if (error) recipes = error;

    if (!isLoading) {
        recipes = data.map(recipe =>
            <Col key={recipe.id.value} style={{marginBottom: '10%'}}>
                <RecipeCard
                    key={recipe.id}
                    recipe={recipe}
                    cld={cld}

                />
            </Col>
        )
    }

    return (
        <div>
            <Container>
                <Row xs={1} sm={2} lg={3} style={{ justifyContent: 'space-evenly', margin: 'auto' }}>
                    {recipes}
                </Row>
            </Container>
        </div>
    );
}

