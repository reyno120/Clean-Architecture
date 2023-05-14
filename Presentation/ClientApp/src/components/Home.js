import { useQuery} from 'react-query';
import RecipeCard from './RecipeCard';
import { Container, Col, Row } from 'reactstrap';

const retrieveRecipes = async () => {
    const response = await fetch('home');
    return await response.json();
}

export default function Home() {
    const { isLoading, data, error } = useQuery("recipes", retrieveRecipes);
    var recipes = [];

    if (error) recipes = error;

    if (!isLoading) {
        recipes = data.map(recipe =>
            <Col key={recipe.id} style={{marginBottom: '10%'}}>
                <RecipeCard
                    key={recipe.id}
                    recipe={recipe}

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

