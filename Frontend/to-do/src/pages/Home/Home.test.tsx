// src/pages/Home/Home.test.tsx
import { render, screen, fireEvent } from '@testing-library/react';
import Home from './Home';
import { vi } from 'vitest';

// ---- Mock the hook ----
const mockUseCards = vi.fn();
vi.mock('./useHome', () => ({
    useCards: () => mockUseCards(),
}));

// ---- Mock child components & antd Spin ----
vi.mock('../../components/Inputs/TextInput', () => ({
    default: ({ value, placeHolder, onChange }: any) => (
        <input
            data-testid="title-input"
            placeholder={placeHolder}
            value={value}
            onChange={(e) => onChange(e.target.value)}
        />
    ),
}));
vi.mock('../../components/Inputs/TextAreaInput', () => ({
    default: ({ value, placeHolder, onChange }: any) => (
        <textarea
            data-testid="desc-input"
            placeholder={placeHolder}
            value={value}
            onChange={(e) => onChange(e.target.value)}
        />
    ),
}));
vi.mock('../../components/Buttons/PrimaryButton', () => ({
    default: ({ text, onClick, disabled }: any) => (
        <button onClick={onClick} disabled={disabled}>{text}</button>
    ),
}));
vi.mock('../../components/Card/Card', () => ({
    default: ({ title, description, complete }: any) => (
        <div>
            <h3>{title}</h3>
            <p>{description}</p>
            <button onClick={complete}>Complete</button>
        </div>
    ),
}));
vi.mock('antd', () => ({
    Spin: () => <div data-testid="spinner-component">loading</div>
}));
describe('<Home />', () => {
    beforeEach(() => {
        vi.clearAllMocks();
    });

    it('shows spinner while loading', () => {
        mockUseCards.mockReturnValue({
            loading: true,
            cards: [],
            form: { title: '', description: '' },
            handleForms: vi.fn(),
            add: vi.fn(),
            complete: vi.fn(),
        });

        render(<Home />);
        expect(screen.getByTestId('spinner-component')).toBeInTheDocument();
    });

    it('renders cards when not loading and calls complete', () => {
        const complete = vi.fn();
        mockUseCards.mockReturnValue({
            loading: false,
            cards: [
                { id: '1', title: 'T1', description: 'D1' },
                { id: '2', title: 'T2', description: 'D2' },
            ],
            form: { title: '', description: '' },
            handleForms: vi.fn(),
            add: vi.fn(),
            complete,
        });

        render(<Home />);
        expect(screen.getByText('T1')).toBeInTheDocument();
        expect(screen.getByText('D2')).toBeInTheDocument();

        // click Complete on the first card
        fireEvent.click(screen.getAllByText('Complete')[0]);
        expect(complete).toHaveBeenCalledWith('1');
    });

    it('updates form via handleForms and triggers add', () => {
        const handleForms = vi.fn();
        const add = vi.fn();

        mockUseCards.mockReturnValue({
            loading: false,
            cards: [],
            form: { title: '', description: '' },
            handleForms,
            add,
            complete: vi.fn(),
        });

        render(<Home />);

        fireEvent.change(screen.getByTestId('title-input'), { target: { value: 'My Task' } });
        fireEvent.change(screen.getByTestId('desc-input'), { target: { value: 'Do stuff' } });

        expect(handleForms).toHaveBeenCalledWith('title', 'My Task');
        expect(handleForms).toHaveBeenCalledWith('description', 'Do stuff');

        fireEvent.click(screen.getByRole('button', { name: /add/i }));
        expect(add).toHaveBeenCalled();
    });

    it('disables Add button when loading', () => {
        mockUseCards.mockReturnValue({
            loading: true,
            cards: [],
            form: { title: '', description: '' },
            handleForms: vi.fn(),
            add: vi.fn(),
            complete: vi.fn(),
        });

        render(<Home />);
        expect(screen.getByRole('button', { name: /add/i })).toBeDisabled();
    });
});
